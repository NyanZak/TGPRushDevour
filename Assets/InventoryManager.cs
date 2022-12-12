using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    public void Awake()
    {
        InitializeWeaponStates();
        Debug.Log("bottleState: " + PlayerPrefs.GetString("bottleState"));

    }
    private void InitializeWeaponStates()
    {
        if (!PlayerPrefs.HasKey("cardState"))
        {
            Debug.Log("WEAPON STATES SET");
            PlayerPrefs.SetString("cardState", "unlocked");
            PlayerPrefs.SetString("keysState", "unlocked");
            PlayerPrefs.SetString("bottleState", "locked");
            PlayerPrefs.SetString("pipeState", "locked");
            PlayerPrefs.SetString("newspaperState", "locked");
            PlayerPrefs.SetString("CurrentWeapon", "card");
            PlayerPrefs.Save();
        }
    }
    public void UnlockWeapon(string weapon)
    {
        PlayerPrefs.SetString(weapon, "unlocked");
        PlayerPrefs.Save();
    }
}
