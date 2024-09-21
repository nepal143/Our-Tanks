using UnityEngine;
using UnityEngine.UI;

public class ActivateParticleEffect : MonoBehaviour
{
    public GameObject particleEffect; // Assign the particle effect prefab in the Unity Editor
    public Image powerBar1;
    public Image powerBar2; // Assign the power bar image in the Unity Editor

    void Update()
    {
        // Check if the "E" key is pressed and the fill amount of the power bar is 1
        if (Input.GetKeyDown(KeyCode.E) && powerBar1 != null && (Mathf.Approximately(powerBar1.fillAmount, 1f) || Mathf.Approximately(powerBar2.fillAmount, 1f)))
        {
            // Activate the particle effect
            if (particleEffect != null)
            {
                particleEffect.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Particle effect is not assigned!");
            }
        }
    }
}
