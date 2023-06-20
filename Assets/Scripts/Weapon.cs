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
    private Dictionary<string, int> weaponIndices;
    public Image cardImage, keysImage, bottleUnlocked, pipeUnlocked, newspaperUnlocked, cardCurrent, keysCurrent, bottleCurrent, pipeCurrent, newspaperCurrent, bottleLocked, pipeLocked, newspaperLocked;

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

        string savedWeapon = PlayerPrefs.GetString("currentWeapon");
        currentWeaponIndex = weaponIndices[savedWeapon];
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];
    }

    private void Update()
    {
        if (bottleState == "unlocked")
        {
            bottleUnlocked.enabled = true;
            bottleLocked.enabled = false;
        }
        else
        {
            bottleUnlocked.enabled = false;
            bottleLocked.enabled = true;
        }

        if (pipeState == "unlocked")
        {
            pipeUnlocked.enabled = true;
            pipeLocked.enabled = false;
        }
        else
        {
            pipeUnlocked.enabled = false;
            pipeLocked.enabled = true;
        }

        if (newspaperState == "unlocked")
        {
            newspaperUnlocked.enabled = true;
            newspaperLocked.enabled = false;
        }
        else
        {
            newspaperUnlocked.enabled = false;
            newspaperLocked.enabled = true;
        }

        if (currentWeaponIndex == weaponIndices["card"])
        {
            cardCurrent.enabled = true;
            keysCurrent.enabled = false;
            bottleCurrent.enabled = false;
            pipeCurrent.enabled = false;
            newspaperCurrent.enabled = false;
        }
        else if (currentWeaponIndex == weaponIndices["keys"])
        {
            cardCurrent.enabled = false;
            keysCurrent.enabled = true;
            bottleCurrent.enabled = false;
            pipeCurrent.enabled = false;
            newspaperCurrent.enabled = false;
        }
        else if (currentWeaponIndex == weaponIndices["bottle"])
        {
            cardCurrent.enabled = false;
            keysCurrent.enabled = false;
            bottleCurrent.enabled = true;
            pipeCurrent.enabled = false;
            newspaperCurrent.enabled = false;
        }
        else if (currentWeaponIndex == weaponIndices["pipe"])
        {
            cardCurrent.enabled = false;
            keysCurrent.enabled = false;
            bottleCurrent.enabled = false;
            pipeCurrent.enabled = true;
            newspaperCurrent.enabled = false;
        }
        else if (currentWeaponIndex == weaponIndices["newspaper"])
        {
            cardCurrent.enabled = false;
            keysCurrent.enabled = false;
            bottleCurrent.enabled = false;
            pipeCurrent.enabled = false;
            newspaperCurrent.enabled = true;
        }
    }
}