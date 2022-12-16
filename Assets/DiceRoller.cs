using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public Sprite[] diceSprites;
    private int currentRoll = 0;
    private void Start()
    {
        StartCoroutine(RollDice());
    }
    IEnumerator RollDice()
    {
        currentRoll = Random.Range(1, 7);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().sprite = diceSprites[currentRoll - 1];
    }


  //  IEnumerator RollDice()
   // {
   //     while (true)
    //    {
     //       currentRoll = Random.Range(1, 7);
     //       GetComponent<Image>().sprite = diceSprites[currentRoll - 1];
      //      yield return new WaitForSeconds(0.5f);
       // }
   // }

}
