using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogueScript2D : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartDialogue();
            Destroy(gameObject);
        }
    }

    public void StartDialogue()
    {
        SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
    }
}
