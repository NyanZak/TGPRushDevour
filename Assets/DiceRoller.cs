using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceRoller : MonoBehaviour
{
    public Sprite[] diceSprites;
    public int targetNumber;
    public KeyCode rollKey;
    private bool isRolling;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetKeyDown(rollKey) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(RollDice());
        }
    }
    IEnumerator RollDice()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomIndex = Random.Range(0, diceSprites.Length);
            image.sprite = diceSprites[randomIndex];
            yield return new WaitForSeconds(0.1f);
        }
        int number = Random.Range(1, 7);
        image.sprite = diceSprites[number - 1];
        if (number == targetNumber)
        {
            Debug.Log("complete");
        }
        isRolling = false;
    }
}