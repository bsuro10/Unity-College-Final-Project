using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfSceneTriggerScript : MonoBehaviour
{
    public GameObject[] enemies;
    public AudioSource backgroundMusicSource;
    public AudioClip backgroundMusicClip;
    public Dialogue dialogue;

    private bool m_isQuestCompleted = false;

    private void Update()
    {
        if (!m_isQuestCompleted && IsQuestCompleted())
        {
            m_isQuestCompleted = true;
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
            SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
        }
    }

    private bool IsQuestCompleted()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.tag != "DeadEnemy")
                return false;
        }
        return true;
    }

    public void EndScene()
    {
        StartCoroutine(MoveToEndSceneAfterDelay(3f));
    }

    IEnumerator MoveToEndSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
    }
}
