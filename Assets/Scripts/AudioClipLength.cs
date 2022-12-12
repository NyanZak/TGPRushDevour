using UnityEngine;
public class AudioClipLength : MonoBehaviour
{
    AudioSource m_AudioSource;
    AudioClip m_AudioClip;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioClip = m_AudioSource.clip;
    }
    void Update()
    {
        Debug.Log("Audio clip length : " + m_AudioSource.time);
    }
}