using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ImageChanger : MonoBehaviour
{
    public Texture2D[] images; // Array of images to cycle through
    public TextMeshProUGUI bulletNameText; // Reference to the TextMeshProUGUI component for bullet name
    private int currentImageIndex = 0; // Index of the current image
    private Image imageComponent; // Reference to the Image component

    void Start()
    {
        // Find the GameObject with the tag "BulleteImage"
        GameObject bulletGameObject = GameObject.FindGameObjectWithTag("BulleteImage");
        if (bulletGameObject != null)
        {
            imageComponent = bulletGameObject.GetComponent<Image>();
            if (imageComponent == null)
            {
                Debug.LogError("Image component not found on GameObject with tag 'BulleteImage'!");
            }
            else if (bulletNameText == null)
            {
                Debug.LogError("TextMeshProUGUI component not assigned for bullet name!");
            }
            else
            {
                // Set the initial image and bullet name
                ChangeImage();
                ChangeBulletName();
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'BulleteImage' not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Increment the image index and loop back to 0 if it exceeds the array length
            currentImageIndex = (currentImageIndex + 1) % images.Length;

            // Change the image and name of the GameObject on the screen
            ChangeImage();
            ChangeBulletName();
        }
    }

    // Method to change the image on the screen
    void ChangeImage()
    {
        // Check if there are images in the array
        if (images.Length > 0)
        {
            // Set the sprite of the Image component to the current image
            imageComponent.sprite = Sprite.Create(images[currentImageIndex], new Rect(0, 0, images[currentImageIndex].width, images[currentImageIndex].height), Vector2.one * 0.5f);
        }
        else
        {
            Debug.LogError("No images found in the array!");
        }
    }

    // Method to change the name of the bullet
    void ChangeBulletName()
    {
        // Get the name of the current image file
        string imageName = Path.GetFileNameWithoutExtension(images[currentImageIndex].name);

        // Set the text of the bullet name to match the image file name
        bulletNameText.text = imageName;
    }
}
