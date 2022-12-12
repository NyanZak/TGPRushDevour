using UnityEngine;
using UnityEngine.UI;
public enum FadeType
{
    FadeIn,
    FadeOut,
    FadeInOut,
    FadeOutIn
}
public class UIFade : MonoBehaviour
{
    [Tooltip("The UI element you want to fade")]
    [SerializeField]
    private MaskableGraphic element;
    [Tooltip("Fade type")]
    [SerializeField]
    private FadeType fadeType;
    [Tooltip("Fade time")]
    [SerializeField]
    private float fadeTime = 1f;
    private Color color;
    private void Awake()
    {
        element.enabled = true;
    }
    void Start()
    {
        color = element.color;
        switch (fadeType)
        {
            case FadeType.FadeIn:
                FadeIn();
                break;
            case FadeType.FadeOut:
                FadeOut();
                break;
            case FadeType.FadeInOut:
                FadeInOut();
                break;
            case FadeType.FadeOutIn:
                FadeOutIn();
                break;
        }
    }
    private void FadeOut()
    {
        LeanTween.alpha(element.rectTransform, 0, fadeTime);
    }
    private void FadeIn()
    {
        LeanTween.alpha(element.rectTransform, 1, fadeTime);
    }
    private void FadeInOut()
    {
        FadeIn();
        LeanTween.delayedCall(fadeTime, FadeOut);
    }
    private void FadeOutIn()
    {
        FadeOut();
        LeanTween.delayedCall(fadeTime, FadeIn);
    }
}