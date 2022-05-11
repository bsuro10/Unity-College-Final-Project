using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogueScript : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
