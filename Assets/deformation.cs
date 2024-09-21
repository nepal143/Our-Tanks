using UnityEngine;

public class TerrainDeformer : MonoBehaviour
{
    public float deformationRadius = 1.0f;
    public float deformationDepth = 0.1f;

    private Terrain terrain;
    private TerrainData terrainData;
    private float[,] originalHeights;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;
        originalHeights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a "Bullet" tag
        if (collision.collider.CompareTag("Finish"))
        {
            // Get the contact point
            ContactPoint contact = collision.contacts[0];
            Vector3 terrainPos = contact.point;
            terrainPos = transform.InverseTransformPoint(terrainPos);
            
            // Deform the terrain at the contact point
            DeformTerrain(terrainPos);
        }
    }

    void DeformTerrain(Vector3 terrainPos)
    {
        int hmWidth = terrainData.heightmapResolution;
        int hmHeight = terrainData.heightmapResolution;
        int posX = (int)(terrainPos.x / terrainData.size.x * hmWidth);
        int posY = (int)(terrainPos.z / terrainData.size.z * hmHeight);

        int startX = Mathf.Max(0, posX - (int)(deformationRadius * hmWidth));
        int endX = Mathf.Min(hmWidth, posX + (int)(deformationRadius * hmWidth));
        int startY = Mathf.Max(0, posY - (int)(deformationRadius * hmHeight));
        int endY = Mathf.Min(hmHeight, posY + (int)(deformationRadius * hmHeight));

        float[,] heights = terrainData.GetHeights(startX, startY, endX - startX, endY - startY);

        for (int y = startY; y < endY; y++)
        {
            for (int x = startX; x < endX; x++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), new Vector2(posX, posY));
                if (distance < deformationRadius)
                {
                    float normalizedDepth = 1.0f - (distance / deformationRadius);
                    float deformAmount = normalizedDepth * deformationDepth;
                    heights[y - startY, x - startX] -= deformAmount;
                }
            }
        }

        terrainData.SetHeights(startX, startY, heights);
    }

    void OnApplicationQuit()
    {
        // Reset the terrain heights to their original values when the application quits
        terrainData.SetHeights(0, 0, originalHeights);
    }
}
