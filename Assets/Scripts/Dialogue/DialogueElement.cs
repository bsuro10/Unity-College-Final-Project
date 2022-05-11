using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]
public class DialogueElement
{
    [TextArea(3,10)]
    public string sentence;

    public Color sentenceColor;

    public AudioClip sentenceAudio;

    public bool addToJournal = false;

    public Sprite characterImage;

    public bool placeImageToTheRight = false;

    public UnityEvent afterDialogueAction = new UnityEvent();
}
