using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private AnimationCurve curve;

    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0f)
        {
            t -= Time.deltaTime;

            float alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
    }

    public IEnumerator FadeOut()
    {
        float t = 1f;

        while (t < 0f)
        {
            t += Time.deltaTime;

            float alpha = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
    }
}
