using UnityEngine;
using UnityEngine.UI;

public class SpecialMoveController : MonoBehaviour
{
    public Image healthBar; // Reference to the health bar image component of the player.
    public float activationThreshold = 0.3f; // Threshold for activating the special move (health percentage).

    private Image specialMoveImage; // Reference to the special move UI sprite image component.

    void Start()
    {
        // Get the Image component of the special move UI sprite.
        specialMoveImage = GetComponent<Image>();

        // Check if the health bar is assigned.
        if (healthBar == null)
        {
            Debug.LogError("Health bar image is not assigned!");
            return;
        }

        // Check if the special move UI sprite is assigned.
        if (specialMoveImage == null)
        {
            Debug.LogError("Special move UI sprite image is not assigned!");
            return;
        }
    }

    void Update()
    {
        // Check if the health bar is assigned and the special move UI sprite is assigned.
        if (healthBar != null && specialMoveImage != null)
        {
            // Calculate the current health percentage.
            float healthPercentage = healthBar.fillAmount;

            // Check if the health percentage is below the activation threshold.
            if (healthPercentage < activationThreshold)
            {
                // Set the fill amount of the special move UI sprite to 1 (fully filled).
                specialMoveImage.fillAmount = 1f;
            }
            else
            {
                // Set the fill amount of the special move UI sprite to 0 (empty).
                specialMoveImage.fillAmount = 0f;
            }
        }
    }
}
