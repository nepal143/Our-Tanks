using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    public Transform target; // The target object to look at     

    void Update()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Get the direction from the Canvas position to the target position
            Vector3 direction = target.position - transform.position;

            // Make the Canvas face the target without rotating in the z-axis
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
