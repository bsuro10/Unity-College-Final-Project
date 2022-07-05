using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNewSceneScript : MonoBehaviour
{

    [SerializeField] private float delay = 0;
    [SerializeField] private int sceneIndex;

    public void MoveToNewScene()
    {
        StartCoroutine(MoveToNewSceneAfterDelay());
    }

    IEnumerator MoveToNewSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

}
