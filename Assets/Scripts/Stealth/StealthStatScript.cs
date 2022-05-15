using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthStatScript : MonoBehaviour
{
    public float maxStealth = 100f;
    public float currentStealth;

    public StealthBarScript stealthBarScript;

    void Start()
    {
        currentStealth = maxStealth;
        stealthBarScript.SetMaxStealth(maxStealth);
    }

    public void TakeStealthDamage(float damage)
    {
        currentStealth -= damage;
        stealthBarScript.SetStealth(currentStealth);
    }
}
