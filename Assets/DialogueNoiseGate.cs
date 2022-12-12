using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Audio;
public class DialogueNoiseGate : MonoBehaviour
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
    public AudioMixer audioMixer;
    public AudioMixerSnapshot noiseGateSnapshot;
//Create an AudioMixer in your Unity project and add an AudioMixerGroup for the audio source that contains the background noise.

//Create an AudioMixerSnapshot for the AudioMixerGroup and name it "Noise Gate".

//Create a new AudioMixerSnapshot and name it "Noise Gate Enabled".

//In the "Noise Gate Enabled" snapshot, add an AudioLowPassFilter effect to the AudioMixerGroup and set the cutoffFrequency to 0.
//This will cause the audio signal to be filtered out below a certain threshold.

//In the "Noise Gate" snapshot, set the AudioMixerGroup's AudioMixerSnapshot to the "Noise Gate Enabled" snapshot.
//This will enable the noise gate when the "Noise Gate" snapshot is active.
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
        noiseGateSnapshot.TransitionTo(0.5f);
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
            Player.GetComponent<Movement>().enabled = true;
            anim.SetBool("walking", true);
            anim.SetBool("idling", false);
            dialoguing = false;

            audioMixer.TransitionToSnapshots(new AudioMixerSnapshot[0], new float[0], 0.5f);
        }
    }
}