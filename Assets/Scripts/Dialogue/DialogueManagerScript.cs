using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManagerScript : MonoBehaviour
{
    public Animator animator;
    public Text dialogueText;
    public Image leftCharacterImage;
    public Image rightCharacterImage;

    private Queue<DialogueElement> m_sentences;
    private UnityEvent m_afterDialogueAction;
    private AudioSource m_audioSource;

    void Start()
    {
        m_sentences = new Queue<DialogueElement>();
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.Stop();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        m_afterDialogueAction = dialogue.afterDialogueAction;
        animator.SetBool("isOpen", true);
        m_sentences.Clear();
        SceneManagerScript.Instance.playerScript.isInDialogue = true;
        foreach (DialogueElement dialogueElement in dialogue.sentences)
        {
            m_sentences.Enqueue(dialogueElement);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (m_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        StopAllCoroutines();
        DialogueElement dialogueElement = m_sentences.Dequeue();
        if (dialogueElement.addToJournal)
            SceneManagerScript.Instance.journalManagerScript.AddTaskToJournal(dialogueElement.sentence);
        PlaceCharacterImage(dialogueElement.characterImage, dialogueElement.placeImageToTheRight);
        dialogueText.color = dialogueElement.sentenceColor;
        StartCoroutine(TypeSentence(dialogueElement.sentence, dialogueElement.sentenceAudio));
        dialogueElement.afterDialogueAction.Invoke();
    }

    private IEnumerator TypeSentence(string sentence, AudioClip sentenceAudio)
    {
        if (sentenceAudio != null)
        {
            m_audioSource.Stop();
            m_audioSource.clip = sentenceAudio;
            m_audioSource.Play();
        }
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        { 
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        SceneManagerScript.Instance.playerScript.isInDialogue = false;
        m_afterDialogueAction.Invoke();
    }

    private void PlaceCharacterImage(Sprite sprite, bool placeImageToTheRight)
    {
        rightCharacterImage.enabled = false;
        leftCharacterImage.enabled = false;
        if (sprite)
        {
            if (placeImageToTheRight)
            {
                rightCharacterImage.sprite = sprite;
                rightCharacterImage.enabled = true;
            }
            else
            {
                leftCharacterImage.sprite = sprite;
                leftCharacterImage.enabled = true;
            }
        }
    }
}
