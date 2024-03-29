using UnityEngine;

/// <summary>
/// Designates dialogue for the GameObject it is placed on
/// </summary>
public class NPCDialogue : MonoBehaviour, IRaycastable
{
    [SerializeField] protected DialogueElement rootDialogue;
    [SerializeField] protected KeyCode interactionKey = KeyCode.E;
    [SerializeField] private string interactionPrompt;
    [SerializeField] private bool neededForQuest;
    private bool firstInteraction = true;
    protected bool isConversing = false;

    public string InteractionPrompt => interactionPrompt;

    public virtual void HandleRaycast(PlayerRaycast player)
    {
        var dialogueController = player.GetComponent<DialogueController>();
        if (Input.GetKeyDown(interactionKey)) HandleDialogue(dialogueController);
    }
    
    private void HandleDialogue(DialogueController dialogueController)
    {
        // Conditions cover entering interaction, advancing interaction, and what happens after interaction
        if (!isConversing)
        {
            dialogueController.StartDialogue(rootDialogue);
            isConversing = true;
        }
        else if (isConversing)
        {
            dialogueController.AdvanceDialogue();
        }
        if (!dialogueController.GetTalkingStatus())
        {
            isConversing = false;
            if (!firstInteraction) return;
            if (neededForQuest) GameManager.instance.informationGathered++;
            GameManager.instance.peopleSpokenTo++;
            firstInteraction = false;
        }
    }
}
