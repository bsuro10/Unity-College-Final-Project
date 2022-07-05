using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private HealthScript healthScript;

    private void Start()
    {
        slider.maxValue = healthScript.currentHealth;
    }

    private void Update()
    {
        slider.value = healthScript.currentHealth;
    }

}
