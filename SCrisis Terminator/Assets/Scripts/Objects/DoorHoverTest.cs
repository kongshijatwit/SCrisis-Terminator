using UnityEngine;

public class DoorHoverTest : MonoBehaviour, IRaycastable
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log($"Display: Press {interactionKey} to open door");


        // Enter building
        if (Input.GetKeyDown(interactionKey))
        {
            Debug.Log("Entering building");
        }
    }
}
