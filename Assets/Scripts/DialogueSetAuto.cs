using UnityEngine;
using System.Collections;
using TMPro;
using System.Runtime.CompilerServices;
using System;

public class DialogueSetAuto : MonoBehaviour
{
    public string[] messages;
    public float delay = 0.1f;
    private string currentMessage;
    private int currentIndex = 0;
    public TextMeshProUGUI textComponent;
    public AudioSource audioSource;
    public Canvas canvas;

    private void Start()
    {
        textComponent.text = string.Empty;
        canvas.gameObject.SetActive(false);
        currentMessage = messages[currentIndex];
        StartCoroutine(TypeMessage());
        audioSource.Play();
    }

    IEnumerator TypeMessage()
    {
        canvas.gameObject.SetActive(true);
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

            yield return new WaitForSeconds(1);

            if (currentIndex < messages.Length - 1)
            {
                currentIndex++;
                currentMessage = messages[currentIndex];
                StartCoroutine(TypeMessage());


            }
            else
            {
                StopCoroutine(TypeMessage());
                audioSource.Stop();


            }
        }
    }