using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Dialogue dialogue;
    public Item item;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManagerScript.Instance.dialogueManagerScript.StartDialogue(dialogue);
            bool isSuccessfullyCollected = SceneManagerScript.Instance.inventoryManagerScript.Add(item);
            if (isSuccessfullyCollected)
                Destroy(gameObject);
        }
    }
}
