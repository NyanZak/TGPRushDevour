using UnityEngine;
public class WeaponSelect : MonoBehaviour
{
    public void SelectWeapon(string weapon)
    {
        PlayerPrefs.SetString("Weapon", weapon);
    }
}