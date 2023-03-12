using UnityEngine;

public class FetchDialogue : NPCDialogue
{
    [SerializeField] private GameObject[] fetchObjects;
    private GameObject givenObject;

    public override void HandleRaycast(PlayerRaycast player)
    {
        var dialogueController = player.GetComponent<DialogueController>();
        givenObject = PickupManager.instance.pickup;
        if (Input.GetKeyDown(interactionKey) && !isConversing)
        {
            dialogueController.StartDialogue(rootDialogue);
            if (givenObject == fetchObjects[0]) dialogueController.AdvanceDialogue();
            isConversing = true;
        }
        else if (Input.GetKeyDown(interactionKey) && !givenObject == fetchObjects[0])
        {
            dialogueController.EndDialogue();
            isConversing = false;
        }
        else
        {
            base.HandleRaycast(player);
        }
    }
}
