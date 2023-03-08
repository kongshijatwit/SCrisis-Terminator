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
        if (rootDialogueBase.Children.Length > 1) { isChoosing = true; }
        else if (rootDialogueBase.Children.Length == 1) { isChoosing = false; }
        rootDialogueBase = rootDialogueBase.Children[UnityEngine.Random.Range(0, rootDialogueBase.Children.Length)];
        OnSentenceChanged();
    }

    private void EndDialogue()
    {
        OnConversationEnded();
        isTalking = false;
    }

    public DialogueElement GetNode() => rootDialogueBase;

    public IEnumerable<DialogueElement> GetAllNodes() => rootDialogueBase.Children;

    public bool GetChoosingStatus() => isChoosing;

    public bool GetTalkingStatus() => isTalking;
}
