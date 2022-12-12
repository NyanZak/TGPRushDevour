using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public Image selectedImage;
    public Image lockedImage;
    public string weapon;

    private void Awake()
    {
        // Get the PlayerPrefs strings for each weapon that you want to track
        string card = PlayerPrefs.GetString("cardState");
        string keys = PlayerPrefs.GetString("keysState");
        string bottle = PlayerPrefs.GetString("bottleState");
        string pipe = PlayerPrefs.GetString("pipeState");
        string newspaper = PlayerPrefs.GetString("newspaperState");
    }
    private void Start()
    {
        // Set the initial state of the image based on whether or not the weapon is unlocked
        selectedImage.gameObject.SetActive(false);
        lockedImage.gameObject.SetActive(false);
    }
    public void OnButtonClicked()
    {
        // Check if the weapon is unlocked
        if (IsWeaponUnlocked(weapon))
        {
            // Set the corresponding image to active
            selectedImage.gameObject.SetActive(true);

            // Update the weapon string to reflect the newly selected weapon
            UpdateWeaponString(weapon);

            // Disable the images for the other buttons
            DisableOtherImages(selectedImage);
        }
    }
    private bool IsWeaponUnlocked(string weapon)
    {
        Debug.Log("IsWeaponUnlocked() called for " + weapon + " button");

        // Get the PlayerPrefs string for the weapon
        var weaponStatus = PlayerPrefs.GetString(weapon + "State");

        // Check if the weapon is unlocked
        if (weaponStatus == "unlocked")
        {
            Debug.Log("UNLOCKED");
            return true;
        }
        else
        {
            Debug.Log("LOCKED");
            return false;
        }
    }
    private void UpdateWeaponString(string weapon)
    {
        // Get the current weapon string from PlayerPrefs
        Debug.Log("Current weapon: " + weapon);

        var currentWeapon = PlayerPrefs.GetString("currentWeapon");

        Debug.Log("Updated weapon: " + PlayerPrefs.GetString("currentWeapon"));
        // Update the current weapon string to the selected weapon
        PlayerPrefs.SetString("currentWeapon", weapon);
    }
    private void DisableOtherImages(Image selectedImage)
    {
        // Get all the buttons in the scene
        var allButtons = GameObject.FindGameObjectsWithTag("WeaponButton");

        // Iterate over the buttons
        foreach (var button in allButtons)
        {
            // Get the image component for the button
            var buttonImage = button.GetComponent<Image>();

            // Check if the button's image is not the selected image
            if (buttonImage != selectedImage)
            {
                    buttonImage.gameObject.SetActive(false);
                // Disable the button's image
            }
        }
    }
} 