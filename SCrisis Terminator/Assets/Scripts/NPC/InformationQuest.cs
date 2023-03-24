using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationQuest : MonoBehaviour, IRaycastable
{
    // Dialogue Attributes
    [SerializeField] private DialogueElement currentDialogue;
    [SerializeField] private DialogueElement questComplete;
    [SerializeField] private DialogueElement secret;
    private bool firstInteraction = true;
    private bool isConversing = false;
    private KeyCode interactionKey = KeyCode.E;

    // Quest Attributes
    private int amountToComplete = 2;
    private bool isQuestComplete = false;

    public virtual void HandleRaycast(PlayerRaycast player)
    {
        // Show tooltip
        Debug.Log($"Display: Press {interactionKey} to speak");


        // Dialogue
        var dialogueController = player.GetComponent<DialogueController>();
        if (Input.GetKeyDown(interactionKey)) HandleInteraction(dialogueController);
    }

    private void HandleInteraction(DialogueController dialogueController)
    {
        if (!isConversing)
        {
            if (CheckCompletion() && firstInteraction) 
            {
                dialogueController.StartDialogue(secret);
            }
            dialogueController.StartDialogue(currentDialogue);
            isConversing = true;
        }
        else if (isConversing)
        {
            dialogueController.AdvanceDialogue();
        }
        if (!dialogueController.GetTalkingStatus())
        {
            isConversing = false;
        }
    }

    private bool CheckCompletion()
    {
        return false;
    }
}
