using System;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private Dialogue dialogue;
    private DialogueElement currentDialogueBase;

    public event Action OnConversationStarted;
    public event Action OnSentenceChanged;
    public event Action OnConversationEnded;

    private bool isDone = false;

    public void StartDialogue(Dialogue newDialogue)
    {
        dialogue = newDialogue;
        currentDialogueBase = dialogue.GetBeginning();
        isDone = false;
        OnConversationStarted();
    }

    public void AdvanceDialogue()
    {
        currentDialogueBase = dialogue.GetNext();
        if (currentDialogueBase == null) 
        {
            Debug.Log("hi");
            EndConversation();
            return; 
        }
        OnSentenceChanged();
    }

    public void EndConversation()
    {
        isDone = true;
        OnConversationEnded();
    }

    public string GetName() => currentDialogueBase.Name;

    public string GetCurrentSentence() => currentDialogueBase.Sentence;

    public bool GetStatus() => isDone;
}
