using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponHolder, currentWeapon;
    public TMP_Text NameBox;
    private Dictionary<string, int> weaponIndices;
    public Image cardImage, keysImage, bottleUnlocked, pipeUnlocked, newspaperUnlocked, cardCurrent, keysCurrent, bottleCurrent, pipeCurrent, newspaperCurrent;

    string cardState;
    string keysState;
    string bottleState;
    string pipeState;
    string newspaperState;

    private void Awake()
    {
        cardState = PlayerPrefs.GetString("cardState");
        keysState = PlayerPrefs.GetString("keysState");
        bottleState = PlayerPrefs.GetString("bottleState");
        pipeState = PlayerPrefs.GetString("pipeState");
        newspaperState = PlayerPrefs.GetString("newspaperState");

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

    private void Update()
    {
        if (bottleState == "unlocked")
        {
            bottleUnlocked.enabled = true;
        }
        else
        {
            bottleUnlocked.enabled = false;
        }
        if (pipeState == "unlocked")
        {
            pipeUnlocked.enabled = true;
        }
        else
        {
            pipeUnlocked.enabled = false;
        }
        if (newspaperState == "unlocked")
        {
            newspaperUnlocked.enabled = true;
        }
        else
        {
            newspaperUnlocked.enabled = false;
        }

        if (currentWeaponIndex == weaponIndices["card"])
        {
            cardCurrent.enabled = true;
        }
        else
        {
            cardCurrent.enabled = false;
        }
        if (currentWeaponIndex == weaponIndices["keys"])
        {
            keysCurrent.enabled = true;
        }
        else
        {
            keysCurrent.enabled = false;
        }
        if (currentWeaponIndex == weaponIndices["bottle"])
        {
            bottleCurrent.enabled = true;
        }
        else
        {
            bottleCurrent.enabled = false;
        }
        if (currentWeaponIndex == weaponIndices["pipe"])
        {
            pipeCurrent.enabled = true;
        }
        else
        {
            pipeCurrent.enabled = false;
        }
        if (currentWeaponIndex == weaponIndices["newspaper"])
        {
            newspaperCurrent.enabled = true;
        }
        else
        {
            newspaperCurrent.enabled = false;
        }
    }
}