using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }
}
