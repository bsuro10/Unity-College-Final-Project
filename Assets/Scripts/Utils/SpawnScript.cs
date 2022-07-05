using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public GameObject[] despawnObjects;

    public void Spawn()
    {
        foreach (GameObject gameObject in spawnObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public void Despawn()
    {
        foreach (GameObject gameObject in despawnObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
