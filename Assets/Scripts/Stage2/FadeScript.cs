using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    [SerializeField]
    private AnimationCurve fadeCurve;
    private Image image;
    private FadeState fadeState;
    public enum FadeState {FadeIn = 0, FadeOut, FadeInOut, FadeLoop}

    private void Awake()
    {
        image = GetComponent<Image>();
        //StartCoroutine(Fade(1, 0));

        OnFade(FadeState.FadeLoop);

    }

    private void Update()
    {
        Color color = image.color;

        if( color.a > 0)
        {
            color.a -= Time.deltaTime;
        }
        if(color.a <1)
        {
            color.a += Time.deltaTime;
        }

        image.color = color;
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch (fadeState)
        { 
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
                case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
        }
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));

            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            //color.a = Mathf.Lerp(start, end, percent);
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;

        }
    }



}
