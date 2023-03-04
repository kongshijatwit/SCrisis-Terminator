using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : Interactable, IInteractable
{
    [SerializeField] private DialogueController dialogControl;
    [SerializeField] private Dialogue dialogue;
    private bool isInteracting = false;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInteracting)
            {
                dialogControl.StartDialogue(dialogue);
                isInteracting = true;
            }
            else if (isInteracting)
            {
                dialogControl.AdvanceDialogue();
            }
            if (dialogControl.GetStatus())
            {
                isInteracting = false;
            }
        }
    }
}
