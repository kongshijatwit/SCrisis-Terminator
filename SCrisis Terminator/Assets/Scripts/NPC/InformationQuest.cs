using UnityEngine;

public class InformationQuest : MonoBehaviour, IRaycastable
{
    // Dialogue Attributes
    [SerializeField] private DialogueElement questDialogue;
    [SerializeField] private DialogueElement questComplete;
    private DialogueElement currentDialogue = null;
    private bool isConversing = false;
    private KeyCode interactionKey = KeyCode.E;

    // Quest Attributes
    private bool questInProgress = false;
    private int amountToComplete = 2;
    private int remainingAmount;
    private string helperSentence;

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
        if(!questInProgress) questInProgress = true;
        currentDialogue = DetermineDialogue(dialogueController);
        HandleConversation(dialogueController);
    }

    private void HandleConversation(DialogueController dialogueController)
    {
        if (!isConversing)
        {
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

    private DialogueElement DetermineDialogue(DialogueController dialogueController)
    {
        if (CheckCompletion()) return questComplete;
        helperSentence = $"*Looks like I have to talk to {amountToComplete - GameManager.instance.peopleSpokenTo} more people*";
        dialogueController.GetLastNode(questDialogue).Sentence = helperSentence;
        return questDialogue;
    }

    private bool CheckCompletion() => GameManager.instance.peopleSpokenTo >= amountToComplete;
}
