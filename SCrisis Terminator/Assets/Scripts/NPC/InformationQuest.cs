using UnityEngine;

public class InformationQuest : MonoBehaviour, IRaycastable
{
    // NPC Attributes
    private KeyCode interactionKey = KeyCode.E;
    public string interactionPrompt;
    public string InteractionPrompt => interactionPrompt;

    // Dialogue Attributes
    [SerializeField] private DialogueElement questDialogue;
    [SerializeField] private DialogueElement questComplete;
    private DialogueElement currentDialogue = null;
    private bool isConversing = false;
    
    // Quest Attributes
    private bool questInProgress = false;
    private int amountToComplete = 2;
    private int remainingAmount;
    private string helperSentence;

    public virtual void HandleRaycast(PlayerRaycast player)
    {
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
        helperSentence = $"*Looks like I have to talk to {amountToComplete - GameManager.instance.informationGathered} more people*";
        dialogueController.GetLastNode(questDialogue).Sentence = helperSentence;
        return questDialogue;
    }

    private bool CheckCompletion() => GameManager.instance.informationGathered >= amountToComplete;
}
