using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombsQuestTriggerScript : MonoBehaviour
{
    public GameObject[] tombs;
    public Dialogue dialogue;
    public AudioSource backgroundMusicSource;
    public AudioClip backgroundMusicClip;
    public AudioClip earthQuackAudioClip;
    public CameraShakeScript cameraShakeScript;

    private bool m_isQuestFinished = false;
    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!m_isQuestFinished)
        {
            if (IsQuestCompleted())
            {
                StartCoroutine(cameraShakeScript.Shake(9f, 0.01f));
                backgroundMusicSource.clip = backgroundMusicClip;
                backgroundMusicSource.Play();
                AudioSource.PlayClipAtPoint(earthQuackAudioClip, transform.position);
                SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
                m_animator.SetBool("isActive", true);
                m_isQuestFinished = true;
            }
        }
    }

    private bool IsQuestCompleted()
    {
        foreach (GameObject tomb in tombs)
        {
            if (tomb.activeSelf)
                return false;
        }
        return true;
    }
}
