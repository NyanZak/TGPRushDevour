using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weapon : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponHolder, currentWeapon;
    public TMP_Text NameBox;
    private Dictionary<string, int> weaponIndices;
    private void Awake()
    {
        weaponIndices = new Dictionary<string, int>
    {
        { "card", 0 },
        { "keys", 1 },
        { "bottle", 2 },
        { "pipe", 3 },
        { "newspaper", 4 }
    };
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];
        int index = 0;
        foreach (Transform child in weaponHolder.transform)
        {
            weapons[index] = child.gameObject;
            weapons[index].SetActive(false);
            index++;
        }
        string Weapon = PlayerPrefs.GetString("currentWeapon");
        NameBox.text = Weapon.ToString();
        currentWeaponIndex = weaponIndices[Weapon];
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];
    }
}