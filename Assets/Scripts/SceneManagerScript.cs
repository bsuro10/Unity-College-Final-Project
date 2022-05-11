using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    public PlayerScript playerScript;
    public DialogueManagerScript dialogueManagerScript;
    public JournalManagerScript journalManagerScript;
    public InventoryManagerScript inventoryManagerScript;

    public static SceneManagerScript Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        // Cache references to all desired variables
        dialogueManagerScript = FindObjectOfType<DialogueManagerScript>();
        playerScript = FindObjectOfType<PlayerScript>();
        journalManagerScript = FindObjectOfType<JournalManagerScript>();
        inventoryManagerScript = FindObjectOfType<InventoryManagerScript>();
    }
}