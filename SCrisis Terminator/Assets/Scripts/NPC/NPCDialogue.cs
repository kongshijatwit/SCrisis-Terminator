using UnityEngine;

public class NPCDialogue : Interactable, IInteractable
{
    [SerializeField] private DialogueController dialogControl;
    [SerializeField] private DialogueElement rootDialogue;
    private bool isInteracting = false;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInteracting)
            {
                dialogControl.StartDialogue(rootDialogue);
                isInteracting = true;
            }
            else if (isInteracting)
            {
                dialogControl.AdvanceDialogue();
            }
            if (!dialogControl.GetTalkingStatus())
            {
                isInteracting = false;
            }
        }
    }
}
