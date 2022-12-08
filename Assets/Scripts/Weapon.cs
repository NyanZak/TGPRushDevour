using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;
    public TMP_Text NameBox;
    private void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];
        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }
    }
    private void Awake()
    {
        string Weapon = PlayerPrefs.GetString("Weapon");
        NameBox.text = Weapon.ToString();
        if (Weapon == "Card")
        {
            currentWeaponIndex = 0;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
        }
        if (Weapon == "Bottle")
        {
            currentWeaponIndex = 1;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
        }
        if (Weapon == "Keys")
        {
            currentWeaponIndex = 2;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
        }
        if (Weapon == "Pipe")
        {
            currentWeaponIndex = 3;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
        }
        if (Weapon == "Newspaper")
        {
            currentWeaponIndex = 4;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
        }
    }
}