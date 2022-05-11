using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objects;
    
    void Start()
    {
        foreach (GameObject gameObject in objects)
        {
            gameObject.SetActive(false);
        }
    }

    public void Spawn()
    {
        foreach (GameObject gameObject in objects)
        {
            gameObject.SetActive(true);
        }
    }
}
