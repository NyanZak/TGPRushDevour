using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ButtonMashBar : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;
    public GameObject Trigger;
    bool success;
    bool firsttime;
    bool decay = false;
    public float decayTimer = 2.5f;

    private void Update()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        fill.color = color;

        if (Input.GetButtonDown("Fire1"))
        {
            decay = true;
            current += 10;
        }

        if (decay)
        {
            decayTimer -= Time.deltaTime;
        }

        if (decayTimer < 0)
        {
            decayTimer = 2.5f;
            current -= 5;
        }

        if (current == maximum)
        {
            Trigger.GetComponent<ButtonMash>().Complete();
        }
    }

}