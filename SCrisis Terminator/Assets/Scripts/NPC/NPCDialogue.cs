using UnityEngine;

/// <summary>
/// Designates dialogue for the GameObject it is placed on
/// </summary>
public class NPCDialogue : MonoBehaviour, IRaycastable
{
    [SerializeField] private DialogueElement rootDialogue;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool isConversing = false;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Show tooltip
        Debug.Log($"Display: Press {interactionKey} to speak");


        // Dialogue
        var dialogueController = player.GetComponent<DialogueController>();
        if (Input.GetKeyDown(interactionKey)) HandleDialogue(dialogueController);
    }

    private void HandleDialogue(DialogueController dialogueController)
    {
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
