using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTagScript : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    public void ChangeTag(string newTag)
    {
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.tag = newTag;
        }
    }
}
