using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    public GameObject portalEffectPrefab; // Prefab for the portal effect

    private GameObject capturedTank; // Reference to the captured tank
    private bool isFirstBullet = true; // Flag to track if this is the first bullet
    private Vector3 secondBulletPosition; // Position where the second bullet hits

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        // Check if this is the first bullet and it hits a tank
        if (isFirstBullet && other.CompareTag("Tank"))
        {
            Debug.Log(isFirstBullet);
            // Capture the tank
            capturedTank = other.gameObject;

            // Instantiate portal effect at the tank's position
            // Instantiate(portalEffectPrefab, capturedTank.transform.position, Quaternion.identity);

            // Set isFirstBullet to false to indicate that the first bullet has been used
            isFirstBullet = false;
            capturedTank.transform.position = new Vector3(323.18f, 10.40219f, 346.66f);

            // Store the position of the tank after the first bullet hit
            secondBulletPosition = capturedTank.transform.position;
        }
        // Check if the bullet collides with an object tagged as "Terrain"
        else if (!isFirstBullet && other.CompareTag("Terrain"))
        {
            // Instantiate portal effect at the position where the second bullet hits
            Instantiate(portalEffectPrefab, secondBulletPosition, Quaternion.identity);

            // Destroy this bullet
            Destroy(gameObject);
            isFirstBullet = true ; 

        }
    }
}
