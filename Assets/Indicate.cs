using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicate : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private float transitionDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            yield return ChangeColor(startColor, endColor, transitionDuration);
            yield return ChangeColor(endColor, endColor, transitionDuration);
        }
    }

    IEnumerator ChangeColor(Color fromColor, Color toColor, float duration)
    {
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            objectRenderer.material.color = Color.Lerp(fromColor, toColor, t);
            yield return null;
        }

        objectRenderer.material.color = toColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
