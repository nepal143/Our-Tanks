using UnityEngine;
using System.Collections ; 
public class ChangeSkyboxOnParticlePlay : MonoBehaviour
{
    public Material newSkyboxMaterial; // Drag the new skybox material here in the Unity Editor

    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(ChangeSkyboxWithDelay(1f)); // Start the coroutine with a 1-second delay
    }
         
    IEnumerator ChangeSkyboxWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Check if the particle system is playing
        if (particleSystem.isPlaying)
        {
            // Change the skybox material
            RenderSettings.skybox = newSkyboxMaterial;
        }
    }
}
