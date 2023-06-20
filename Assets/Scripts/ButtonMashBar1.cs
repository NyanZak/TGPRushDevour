using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode()]
public class ButtonMashBar1 : MonoBehaviour
{
    public int minValue, maxValue, currentValue, increaseAmount, decreaseAmount;
    public Image mask, fill;
    public Color color;
    public GameObject Trigger;
    public float decayTimer = 5f;
    private bool decayStarted = false;
    private void Update()
    {
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        float fillAmount = Mathf.InverseLerp(minValue, maxValue, currentValue);
        mask.fillAmount = Mathf.Clamp01(fillAmount);
        fill.color = color;
        if (Input.GetButtonDown("Fire1"))
        {
            currentValue += increaseAmount;
            if (!decayStarted)
            {
                decayStarted = true;
                StartCoroutine(Decay());
            }
        }
        if (currentValue == maxValue)
        {
            Trigger.GetComponent<ButtonMash1>().Complete();
            currentValue = minValue - 1;
        }
        if (currentValue == minValue)
        {
            Trigger.GetComponent<ButtonMash1>().Fail();
        }
    }
    private IEnumerator Decay()
    {
        while (true)
        {
            yield return new WaitForSeconds(decayTimer);
            currentValue -= decreaseAmount;
        }
    }
}