using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    public new Light light;
    //public AudioSource lightsound;
    public float minTime;
    public float maxTime;
    public float timer;
    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        LightsFlickering();
    }
    void LightsFlickering()
    {
        if (timer >0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                light.enabled = !light.enabled;
                timer = Random.Range(minTime, maxTime);
               // lightsound.Play();
            }
        }
    }
}
