using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public Image selectedImage;
    public string weapon;

    private void Awake()
    {
        string card = PlayerPrefs.GetString("cardState");
        string keys = PlayerPrefs.GetString("keysState");
        string bottle = PlayerPrefs.GetString("bottleState");
        string pipe = PlayerPrefs.GetString("pipeState");
        string newspaper = PlayerPrefs.GetString("newspaperState");
    }
    private void Start()
    {
        selectedImage.gameObject.SetActive(false);
    }
    public void OnButtonClicked()
    {
        if (IsWeaponUnlocked(weapon))
        {
            selectedImage.gameObject.SetActive(true);
            UpdateWeaponString(weapon);
            DisableOtherImages(selectedImage);
        }
    }
    private bool IsWeaponUnlocked(string weapon)
    {
        var weaponStatus = PlayerPrefs.GetString(weapon + "State");
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
        var currentWeapon = PlayerPrefs.GetString("currentWeapon");
        PlayerPrefs.SetString("currentWeapon", weapon);
    }
    private void DisableOtherImages(Image selectedImage)
    {
        var allButtons = GameObject.FindGameObjectsWithTag("WeaponButton");
        foreach (var button in allButtons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != selectedImage)
            {
                    buttonImage.gameObject.SetActive(false);
            }
        }
    }
} 