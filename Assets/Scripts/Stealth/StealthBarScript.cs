using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealthBarScript : MonoBehaviour
{

    public Slider slider;

    public void SetMaxStealth(float amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }

    public void SetStealth(float amount)
    {
        slider.value = amount;
    }
}
