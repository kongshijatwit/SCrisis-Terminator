using UnityEngine;

public class DoorHoverTest : MonoBehaviour, IRaycastable
{
    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        Debug.Log("Display: Open Door");


        // Enter building
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entering building");
        }
    }
}
