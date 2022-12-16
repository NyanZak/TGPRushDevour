using UnityEngine;
using System.Collections;
using TMPro;
public class DialogueRandomAuto : MonoBehaviour
{
    public string[] messages;
    public float delay = 0.1f;
    private string currentMessage;
    private int currentIndex = 0;
    //public GameObject interactable;
    public TextMeshProUGUI textComponent;
   // public AudioSource voiceOverAudioSource;
    void Start()
    {
        currentMessage = messages[Random.Range(0, messages.Length)];
        StartCoroutine(TypeMessage());
    }
    IEnumerator TypeMessage()
    {
        string colourblind = PlayerPrefs.GetString("colourblind");
        if (colourblind == "on")
        {
            for (int i = 0; i < messages.Length; i++)
            {
                if (messages[i].Contains("red"))
                {
                    messages[i] = messages[i].Replace("red", "orange");
                }
                if (messages[i].Contains("green"))
                {
                    messages[i] = messages[i].Replace("green", "blue");
                }
            }
        }
        bool isAddingRichText = false;
        textComponent.text = "";
        for (int i = 0; i < currentMessage.Length; i++)
        {
            if (currentMessage[i] == '<' || isAddingRichText)
            {
                isAddingRichText = true;
                textComponent.text += currentMessage[i];
                if (currentMessage[i] == '>')
                {
                    isAddingRichText = false;
                }
            }
            else
            {
                textComponent.text += currentMessage[i];
                yield return new WaitForSeconds(delay);
            }
        }
        yield return new WaitForSeconds(2);
        currentMessage = messages[Random.Range(0, messages.Length)];
        StopCoroutine(TypeMessage());
        StartCoroutine(TypeMessage());
    }
}