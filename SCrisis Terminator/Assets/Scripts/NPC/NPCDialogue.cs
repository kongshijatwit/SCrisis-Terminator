using UnityEngine;

public class NPCDialogue : MonoBehaviour, IRaycastable
{
    [SerializeField] private DialogueElement rootDialogue;
    private bool isConversing = false;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Show tooltip
        Debug.Log("Display: Press E to speak");

        // Dialogue
        var dialogueController = player.GetComponent<DialogueController>();
        if (Input.GetKeyDown(KeyCode.E)) HandleDialogue(dialogueController);
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
