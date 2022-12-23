using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public class DialogueSet : MonoBehaviour
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
    public AudioSource audioSource;
    public AudioClip[] audioClips; 
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
        Player.GetComponent<Movement>().enabled = false;
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
        audioSource.clip = audioClips[index];
        audioSource.PlayDelayed(1);
        index = 0;
        string colourblind = PlayerPrefs.GetString("colourblind");
        if (colourblind == "off")
        {
        }
        else if (colourblind == "on")
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("red"))
                {
                    lines[i] = lines[i].Replace("red", "orange");
                }
                if (lines[i].Contains("green"))
                {
                    lines[i] = lines[i].Replace("green", "blue");
                }
            }
        }
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        bool isAddingRichText = false;

        foreach (char c in lines[index].ToCharArray())
        {
            if (c == '<' || isAddingRichText)
            {
                isAddingRichText = true;
                textComponent.text += c;
                if (c == '>')
                {
                    isAddingRichText = false;
                }
            }
            else
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[index];
            audioSource.Play();
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            Player.GetComponent<Movement>().enabled = true;
            anim.SetBool("walking", true);
            anim.SetBool("idling", false);
            dialoguing = false;
        }
    }
}