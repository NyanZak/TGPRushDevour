using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public void KeyCardSelect()
    {
        PlayerPrefs.SetString("Weapon", "Card");
        Debug.Log("CARD");
    }
    public void BottleSelect()
    {
        PlayerPrefs.SetString("Weapon", "Bottle");
        Debug.Log("BOTTLE");
    }
    public void KeysSelect()
    {
        PlayerPrefs.SetString("Weapon", "Keys");
        Debug.Log("KEYS");
    }
    public void PipeSelect()
    {
        PlayerPrefs.SetString("Weapon", "Pipe");
        Debug.Log("PIPE");
    }
    public void NewspaperSelect()
    {
        PlayerPrefs.SetString("Weapon", "Newspaper");
        Debug.Log("NEWSPAPER");
    }
}
