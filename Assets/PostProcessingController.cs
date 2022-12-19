using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PostProcessingController : MonoBehaviour
{
    Volume volume;
    private ColorAdjustments colorAdjustments;
    void Awake()
    {
        volume = GetComponent<Volume>();

        if (volume.profile.TryGet(out colorAdjustments))
        {
           colorAdjustments.postExposure.value = GameManager.instance.postExposure;
           colorAdjustments.contrast.value = GameManager.instance.contrast;
        }
    }
}