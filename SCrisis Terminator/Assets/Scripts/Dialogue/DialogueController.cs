using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private DialogueElement rootDialogueBase = null;
    private bool isChoosing = false;
    private bool isTalking = false;

    public event Action OnConversationStarted = delegate { };
    public event Action OnSentenceChanged = delegate { };
    public event Action OnConversationEnded = delegate { };

    public void StartDialogue(DialogueElement newDialogue)
    {
        rootDialogueBase = newDialogue;
        isTalking = true;
        OnConversationStarted();
    }

    public void AdvanceDialogue()
    {
        if (rootDialogueBase == null || rootDialogueBase.Children.Length < 1) 
        {
            EndDialogue();
            return; 
        }
        if (rootDialogueBase.Children.Length > 1) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isChoosing = true;
            OnSentenceChanged();
            return;
        }
        else if (rootDialogueBase.Children.Length == 1) 
        {
            isChoosing = false;
        }
        rootDialogueBase = rootDialogueBase.Children[0];
        OnSentenceChanged();
    }

    public void EndDialogue()
    {
        OnConversationEnded();
        isTalking = false;
    }

    public void SelectChoice(DialogueElement node)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rootDialogueBase = node;
        isChoosing = false;
        OnSentenceChanged();
    }

    public DialogueElement GetNode() => rootDialogueBase;

    public IEnumerable<DialogueElement> GetAllNodes() => rootDialogueBase.Children;

    public bool GetChoosingStatus() => isChoosing;

    public bool GetTalkingStatus() => isTalking;
}
