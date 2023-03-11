using UnityEngine;

public class Coat : MonoBehaviour, IRaycastable
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log($"Display: Press {interactionKey} to pickup");


        // Pickup Logic
        if(Input.GetKeyDown(interactionKey))
        {
            PickupManager.instance.SetPickup(gameObject);
            Debug.Log($"You have picked up {gameObject.name}");
        }
    }
}
