using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private DialogueElement currentDialogue = null;
    private bool isChoosing = false;
    private bool isTalking = false;

    public event Action OnConversationStarted = delegate { };
    public event Action OnSentenceChanged = delegate { };
    public event Action OnConversationEnded = delegate { };

    public void StartDialogue(DialogueElement newDialogue)
    {
        currentDialogue = newDialogue;
        isTalking = true;
        OnConversationStarted();
    }

    public void AdvanceDialogue()
    {
        // Handles null exception and when there are zero nodes in children
        if (currentDialogue == null || currentDialogue.Children.Length < 1) 
        {
            EndDialogue();
            return; 
        }

        // Decides when to initiate the choosing state
        if (currentDialogue.Children.Length > 1) 
        {
            // Unlock cursor so player can select the choices
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isChoosing = true;
            OnSentenceChanged();
            return;
        }

        // If it's just one child, safe to assume player is not choosing anything
        else if (currentDialogue.Children.Length == 1) 
        {
            isChoosing = false;
        }

        // Advance node index and call changed event
        currentDialogue = currentDialogue.Children[0];
        OnSentenceChanged();
    }

    public void EndDialogue()
    {
        OnConversationEnded();
        isTalking = false;
    }

    public void SelectChoice(DialogueElement node)
    {
        // Re-lock the cursor to regain first person environment
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Make sure to reset boolean so that next AdvanceDialogue call doesn't break UI
        currentDialogue = node;
        isChoosing = false;
        OnSentenceChanged();
    }

    
    #region Getters
	public DialogueElement GetNode() => currentDialogue;
	
    public IEnumerable<DialogueElement> GetAllNodes() => currentDialogue.Children;
	
    public bool GetChoosingStatus() => isChoosing;
	
    public bool GetTalkingStatus() => isTalking;

    public DialogueElement GetLastNode(DialogueElement startNode)
    {
        if(startNode == null) return null;
        while (startNode.Children.Length > 0)
        {
            startNode = startNode.Children[0];
        }
        return startNode;
    }
    #endregion
}
