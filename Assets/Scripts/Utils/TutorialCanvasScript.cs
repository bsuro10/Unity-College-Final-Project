using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvasScript : MonoBehaviour
{
    [SerializeField] private Canvas tutorialCanvas;

    void Start()
    {
        tutorialCanvas.enabled = false;
    }

    public void OpenTutorialCanvas()
    {
        tutorialCanvas.enabled = true;
        Cursor.visible = true;
    }

    public void OnCloseButtonClick()
    {
        tutorialCanvas.enabled = false;
        Cursor.visible = false;
    }
}
