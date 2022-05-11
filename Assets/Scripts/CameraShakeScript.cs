using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float randomXPosition = Random.Range(-5f, 5f) * magnitude;
            float randomYPosition = Random.Range(-5f, 5f) * magnitude;
            transform.localPosition = new Vector3(randomXPosition, originalPosition.y, randomYPosition);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
