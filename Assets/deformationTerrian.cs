// using UnityEngine;

// public class TerrainDeformer : MonoBehaviour
// {
//     public Terrain terrain;
//     public float deformationRadius = 1.0f;
//     public float deformationDepth = 0.1f;
//         private Vector3 previousPosition;
//      private void Start()
//     {
//         // Store the initial position of the bullet
//         previousPosition = transform.position;
//                 if (terrain == null)
//         {
//             Debug.LogError("Terrain not found in the scene!");
//         }
//     }

//     private void Update()
//     {
//         // Detect collision with the terrain using raycasting
//         RaycastHit hit;
//         if (Physics.Raycast(previousPosition, transform.position - previousPosition, out hit, Vector3.Distance(previousPosition, transform.position)))
//         {
//             if (hit.collider.gameObject == terrain.gameObject)
//             {
//                 // Convert hit point to terrain local position
//                 Vector3 terrainPos = terrain.transform.InverseTransformPoint(hit.point);
//                 // Deform the terrain   
//                 DeformTerrain(terrainPos);
//             }
//         }

//         // Update the previous position for the next frame
//         previousPosition = transform.position;
//     }


//    private void OnCollisionEnter(Collision collision)
//     {
//         // Check if the collided object has a Rigidbody component
//         Terrain terrain = collision.collider.GetComponent<Terrain>();
//         if (terrain != null)
//         {
//             // Get the contact point
//             ContactPoint contact = collision.contacts[0];
//             // Calculate the position on the terrain where the collision occurred
//             Vector3 terrainPos = contact.point;
//             // Convert world position to terrain local position
//             terrainPos = terrain.transform.InverseTransformPoint(terrainPos);
//             // Deform the terrain
//             DeformTerrain(terrain, terrainPos);
//         }
//     }

//     private void DeformTerrain(Vector3 terrainPos)
//     {
//          if (terrain == null)
//         {
//             Debug.LogError("Terrain reference is null!");
//             return;
//         }
//         // Get the terrain data
//         TerrainData terrainData = terrain.terrainData;
//         int hmWidth = terrainData.heightmapResolution;
//         int hmHeight = terrainData.heightmapResolution;
//         int posX = (int)(terrainPos.x / terrainData.size.x * hmWidth);
//         int posY = (int)(terrainPos.z / terrainData.size.z * hmHeight);

//         // Calculate the bounds of the area to deform
//         int startX = Mathf.Max(0, posX - (int)(deformationRadius * hmWidth));
//         int endX = Mathf.Min(hmWidth, posX + (int)(deformationRadius * hmWidth));
//         int startY = Mathf.Max(0, posY - (int)(deformationRadius * hmHeight));
//         int endY = Mathf.Min(hmHeight, posY + (int)(deformationRadius * hmHeight));

//         // Get the current heights of the terrain
//         float[,] heights = terrainData.GetHeights(startX, startY, endX - startX, endY - startY);

//         // Modify the terrain heights within the deformation radius
//         for (int y = startY; y < endY; y++)
//         {
//             for (int x = startX; x < endX; x++)
//             {
//                 // Calculate the distance from the current terrain point to the collision point
//                 float distance = Vector2.Distance(new Vector2(x, y), new Vector2(posX, posY));
//                 // If within the deformation radius, deform the terrain
//                 if (distance < deformationRadius)
//                 {
//                     // Calculate the normalized depth based on distance from the collision point
//                     float normalizedDepth = 1.0f - (distance / deformationRadius);
//                     // Apply deformation depth
//                     float deformAmount = normalizedDepth * deformationDepth;
//                     // Apply deformation to the terrain height
//                     heights[y - startY, x - startX] -= deformAmount;
//                 }
//             }
//         }

//         // Apply the modified heights to the terrain
//         terrainData.SetHeights(startX, startY, heights);
//     }
// }
