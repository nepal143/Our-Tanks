using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDomain : MonoBehaviour
{
    public GameObject particleEffect;
    public AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // You can optionally get the AudioSource component if it's not assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the particle effect is inactive
        if (particleEffect != null && !particleEffect.activeSelf)
        {
            // If the particle effect is inactive, disable the audio
            if (audioSource != null)
            {
                audioSource.enabled = true;
            }
        }
        else
        {
            // If the particle effect is active, enable the audio
            if (audioSource != null)
            {
                audioSource.enabled = false;
            }   
        }
    }
}
