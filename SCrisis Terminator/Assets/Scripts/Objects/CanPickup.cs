using UnityEngine;

public class CanPickup : MonoBehaviour, IRaycastable
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    private bool status = false;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log($"Display: Press {interactionKey} to pickup");


        // Pickup Logic
        if(Input.GetKeyDown(interactionKey))
        {
            status = PickupManager.instance.SetPickup(gameObject, status);
            gameObject.GetComponent<MeshRenderer>().enabled = !status;
        }
    }
}
