using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
    public AudioMixerGroup group;
    public bool mute = false;
    public void Stop()
    {
        source.Stop();
    }
    public void Pause()
    {
        source.Pause();
    }
    public void Resume()
    {
        source.UnPause();
    }
}