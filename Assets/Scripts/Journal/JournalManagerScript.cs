using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManagerScript : MonoBehaviour
{
    public Animator animator;
    public Text journalText;

    private bool isOpen = false;
    private Journal m_journal = new Journal();

    void Start()
    {
        m_journal.tasks = new List<string>();
        journalText.text = "";
    }

    public void AddTaskToJournal(string task)
    {
        m_journal.tasks.Add(task);
        journalText.text += "* " + task + "\n";
    }

    public void ToggleJournal()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
        if (isOpen)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }

}
