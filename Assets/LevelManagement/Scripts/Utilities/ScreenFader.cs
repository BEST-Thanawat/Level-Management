using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField]
    private float _solidAlpha = 1f, _clearAlpha = 0f, _fadeDuration = 2f;
    public float FadeDuration { get => _fadeDuration; }

    [SerializeField]
    private MaskableGraphic[] graphicsFade;

    private void SetAplha(float alpha) 
    {
        foreach (MaskableGraphic graphic in graphicsFade)
        {
            if(graphic != null)
            {
                graphic.canvasRenderer.SetAlpha(alpha);
            }
        }
    }
    private void Fade(float targetAlpha, float duration)
    {
        foreach (MaskableGraphic graphic in graphicsFade)
        {
            if (graphic != null)
            {
                graphic.CrossFadeAlpha(targetAlpha, duration, true);
            }
        }
    }

    public void FadeOff()
    {
        SetAplha(_solidAlpha);
        Fade(_clearAlpha, _fadeDuration);
    }

    public void FadeOn()
    {
        SetAplha(_clearAlpha);
        Fade(_solidAlpha, _fadeDuration);
    }
}
