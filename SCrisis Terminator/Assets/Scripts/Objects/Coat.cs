using UnityEngine;

public class Coat : MonoBehaviour, IRaycastable
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool pickedUp = false;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log($"Display: Press {interactionKey} to pickup");


        // Pickup Logic
        if(Input.GetKeyDown(interactionKey) && !pickedUp)
        {
            pickedUp = true;
            PickupManager.instance.SetPickup(gameObject, pickedUp);
            Debug.Log($"You have picked up {gameObject.name}");
        }
        else if(Input.GetKeyDown(interactionKey) && pickedUp)
        {
            pickedUp = false;
            PickupManager.instance.SetPickup(gameObject, pickedUp);
            Debug.Log($"You have put down up {gameObject.name}");
        }
    }
}
