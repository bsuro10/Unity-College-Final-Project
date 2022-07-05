using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterlifeDoorScript : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            SceneManager.LoadScene(nextSceneIndex);
    }
}
