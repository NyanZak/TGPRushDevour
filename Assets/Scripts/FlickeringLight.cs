using UnityEngine;
public class FlickeringLight : MonoBehaviour
{
    public new Light light;
    public AudioSource lightsound;
    public float minFlickerInterval;
    public float maxFlickerInterval;
    public float flickerIntensity;
    public float timer;
    private void Start()
    {
        timer = Random.Range(minFlickerInterval, maxFlickerInterval);
    }
    private void Update()
    {
        UpdateFlicker();
    }
    void UpdateFlicker()
    {
        if (timer <= 0)
        {
            light.enabled = !light.enabled;
            if (light.enabled)
            {
                light.intensity = flickerIntensity;
            }
            else
            {
                light.intensity = 0;
            }
            if (lightsound != null)
            {
                lightsound.Play();
            }
            timer = Random.Range(minFlickerInterval, maxFlickerInterval);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}