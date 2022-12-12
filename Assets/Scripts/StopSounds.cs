using UnityEngine;
public class StopSounds : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    public void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}