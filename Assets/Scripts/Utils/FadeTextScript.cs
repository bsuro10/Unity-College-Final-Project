using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTextScript : MonoBehaviour
{
    public Text[] texts;
    public Color fadeColor;
    public int fadeTime = 5;

    private bool isTriggered = false;

    void Start()
    {
        foreach (Text text in texts)
        {
            text.color = Color.clear;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }

    void Update()
    {
        FadeText();
    }

    private void FadeText()
    {
        if (isTriggered)
            foreach (Text text in texts)
            {
                text.color = Color.Lerp(text.color, fadeColor, fadeTime * Time.deltaTime);
            }
        else
            foreach (Text text in texts)
            {
                text.color = Color.Lerp(text.color, Color.clear, fadeTime * Time.deltaTime);
            }
    }
}
