using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBloomLightFadeScript : MonoBehaviour
{
    public Transform bloomLight;
    public float fadeTime = 1f;
    public float maximumScaleSize = 5.0f;

    void Start()
    {
        bloomLight.localScale = new Vector3(bloomLight.localScale.x, bloomLight.localScale.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeIn()
    {
        while (bloomLight.localScale.z < maximumScaleSize)
        {
            bloomLight.localScale = new Vector3(bloomLight.localScale.x, bloomLight.localScale.y, bloomLight.localScale.z + (Time.deltaTime / fadeTime));
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        while (bloomLight.localScale.z > 0.0f)
        {
            bloomLight.localScale = new Vector3(bloomLight.localScale.x, bloomLight.localScale.y, bloomLight.localScale.z - (Time.deltaTime / fadeTime));
            yield return null;
        }
    }
}
