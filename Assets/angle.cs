using UnityEngine;
using TMPro;

public class BarrelAngleDisplay : MonoBehaviour
{
    public Transform barrelTransform; // Reference to the barrel's transform
    public TextMeshProUGUI angleText; // Reference to the TextMeshPro component to display the angle

    void Update()
    {
        // Check if the barrel transform and TextMeshPro component are assigned
        if (barrelTransform != null && angleText != null)
        {
            // Get the X rotation of the barrel
            float xRotation = barrelTransform.localRotation.eulerAngles.x;

            // Display the X rotation on the TextMeshPro component
            angleText.text = "Barrel Angle: " + xRotation.ToString("F2") + "°";
        }
        else
        {
            // Log an error if either reference is not assigned
            Debug.LogError("BarrelAngleDisplay: Barrel transform or TextMeshPro component not assigned.");
        }
    }
}
