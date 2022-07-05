using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndOfSceneTriggerScript : MonoBehaviour
{
    public GameObject[] enemies;
    public Dialogue dialogue;
    public UnityEvent actions = new UnityEvent();
    public int amountOfDeadEnemiesNeeded;

    private bool m_isQuestCompleted = false;

    private void Awake()
    {
        if (amountOfDeadEnemiesNeeded == 0)
            amountOfDeadEnemiesNeeded = enemies.Length;
    }

    private void Update()
    {
        if (!m_isQuestCompleted && IsQuestCompleted())
        {
            m_isQuestCompleted = true;
            actions.Invoke();
        }
    }

    private bool IsQuestCompleted()
    {
        int amountOfDeadEnemies = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.tag == "DeadEnemy")
                amountOfDeadEnemies++;
        }
        return amountOfDeadEnemies == amountOfDeadEnemiesNeeded;
    }

    public void StartDialogue()
    {
        SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
    }

    public void EndScene(int sceneIndex)
    {
        StartCoroutine(MoveToEndSceneAfterDelay(3f, sceneIndex));
    }

    IEnumerator MoveToEndSceneAfterDelay(float delay, int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
