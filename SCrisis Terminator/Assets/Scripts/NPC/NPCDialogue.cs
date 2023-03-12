using UnityEngine;

/// <summary>
/// Designates dialogue for the GameObject it is placed on
/// </summary>
public class NPCDialogue : MonoBehaviour, IRaycastable
{
    [SerializeField] protected DialogueElement rootDialogue;
    [SerializeField] protected KeyCode interactionKey = KeyCode.E;
    protected bool isConversing = false;

    public virtual void HandleRaycast(PlayerRaycast player)
    {
        // Show tooltip
        Debug.Log($"Display: Press {interactionKey} to speak");


        // Dialogue
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
        }
    }
}
