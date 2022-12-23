using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        dialogue.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        dialogue.SetActive(false);
    }
}
