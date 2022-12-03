using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Dialogue : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
    public Canvas canvas;
    [SerializeField] private InputActionReference actionReference;
    public TextMeshProUGUI textComponent;
    bool dialoguing = false;
    public string[] lines;
    public float textSpeed;
    private int index;
    private void Awake()
    {
        if (!(actionReference.action.interactions.Contains("TapInteraction") && actionReference.action.interactions.Contains("HoldInteraction")))
        {
            return;
        }
    }
    void Start()
    {
        textComponent.text = string.Empty;
        canvas.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartDialouge();
        dialoguing = true;
        Player.GetComponent<movement>().enabled = false;
        anim.SetBool("walking", false);
        anim.SetBool("idling", true);
        canvas.gameObject.SetActive(true);

    }

    void Update()
    {
        actionReference.action.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                if (dialoguing == true)
                {
                    if (textComponent.text == lines[index])
                    {
                        NextLine();
                    }
                    else
                    {
                        StopAllCoroutines();
                        textComponent.text = lines[index];
                    }
                }
            }
        };
   }
    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            Player.GetComponent<movement>().enabled = true;
            anim.SetBool("walking", true);
            anim.SetBool("idling", false);
            dialoguing = false;
        }
    }
}