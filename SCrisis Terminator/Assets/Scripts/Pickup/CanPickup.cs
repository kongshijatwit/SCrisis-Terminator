using UnityEngine;

public class CanPickup : MonoBehaviour, IRaycastable
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private string interactionPrompt;
    public string InteractionPrompt => interactionPrompt;
    private bool hasBeenPickedUp = false;


    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log($"Display: Press {interactionKey} to pickup");


        // Pickup Logic
        if(Input.GetKeyDown(interactionKey))
        {
            hasBeenPickedUp = player.GetComponent<PickupHandler>().SetPickup(gameObject, hasBeenPickedUp);
            gameObject.GetComponent<MeshRenderer>().enabled = !hasBeenPickedUp;
        }
    }
}
