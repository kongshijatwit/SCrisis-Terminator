using UnityEngine;

public class NPCDialogue : MonoBehaviour, IRaycastable
{
    [SerializeField] private DialogueElement rootDialogue;
    private bool isInteracting = false;

    public void HandleRaycast(PlayerRaycast player)
    {
        var dialogueController = player.GetComponent<DialogueController>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInteracting)
            {
                dialogueController.StartDialogue(rootDialogue);
                isInteracting = true;
            }
            else if (isInteracting)
            {
                dialogueController.AdvanceDialogue();
            }
            if (!dialogueController.GetTalkingStatus())
            {
                isInteracting = false;
            }
        }
    }
}
