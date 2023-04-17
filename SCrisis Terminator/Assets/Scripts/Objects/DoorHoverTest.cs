using UnityEngine;

public class DoorHoverTest : MonoBehaviour, IRaycastable
{
    public string interactionPrompt;
    public string InteractionPrompt => throw new System.NotImplementedException();

    public void HandleRaycast(PlayerRaycast player)
    {
        // Tooltip
        //Debug.Log("Display: Open Door");


        // Enter building
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entering building");
        }
    }
}




