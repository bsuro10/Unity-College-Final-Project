using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Canvas exitMenuCanvas;
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        exitMenuCanvas.enabled = false;
    }

    public void onExitButtonClicked()
    {
        exitMenuCanvas.enabled = true;
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    public void onNoExitConfirmButtonClicked()
    {
        exitMenuCanvas.enabled = false;
        playButton.enabled = true;
        exitButton.enabled = true;
    }

    public void onYesExitConfirmButtonClicked()
    {
        Application.Quit();
    }

    public void onPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
