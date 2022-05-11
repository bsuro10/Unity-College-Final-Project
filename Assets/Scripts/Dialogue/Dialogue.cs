using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]
public class Dialogue
{
    public DialogueElement[] sentences;
    public UnityEvent afterDialogueAction = new UnityEvent();
}
