using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBloomLightFadeScript : MonoBehaviour
{
    public Transform bloomLight;
    public float fadeTime = 1f;
    public float maximumScaleSize = 2.0f;

    void Start()
    {
        bloomLight.localScale = new Vector3(bloomLight.localScale.x, 0f, bloomLight.localScale.z);
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
        if (bloomLight)
        {
            while (bloomLight.localScale.y < maximumScaleSize)
            {
                bloomLight.localScale = new Vector3(bloomLight.localScale.x, bloomLight.localScale.y + (Time.deltaTime / fadeTime), bloomLight.localScale.z);
                yield return null;
            }
        }
    }

    public IEnumerator FadeOut()
    {
        if (bloomLight)
        {
            while (bloomLight.localScale.y > 0.0f)
            {
                bloomLight.localScale = new Vector3(bloomLight.localScale.x, bloomLight.localScale.y - (Time.deltaTime / fadeTime), bloomLight.localScale.z);
                yield return null;
            }
        }
    }
}
