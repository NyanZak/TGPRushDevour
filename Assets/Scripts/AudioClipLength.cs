using UnityEngine;
using UnityEngine.Audio;

public class AudioClipLength : MonoBehaviour
{
    //Make sure your GameObject has an AudioSource component first
    AudioSource m_AudioSource;

    //Make sure to set an Audio Clip in the AudioSource component
    AudioClip m_AudioClip;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_AudioSource = GetComponent<AudioSource>();

        //Set the original AudioClip as this clip
        m_AudioClip = m_AudioSource.clip;
    }

    void Update()
    {
        Debug.Log("Audio clip length : " + m_AudioSource.time);
    }
}