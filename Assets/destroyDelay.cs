using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Call the DestroyObjectDelayed method after 4 seconds
        Invoke("DestroyObjectDelayed", 4f);
    }

    // Method to destroy the GameObject after a delay
    void DestroyObjectDelayed()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
