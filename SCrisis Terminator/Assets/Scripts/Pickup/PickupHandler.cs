using UnityEngine;
using System;

/// <summary>
/// Handles picking up and holding objects
/// </summary>
public class PickupHandler : MonoBehaviour
{
    public GameObject pickup = null;  // Only public for testing
    public event Action UpdatePickup = delegate { };

    /// <summary>
    /// Sets the current pickup to the new one depending on its status
    /// </summary>
    /// <param name="newPickup">Object to attempt picking up</param>
    /// <param name="status">Has the object already been picked up</param>
    /// <returns>True if the object has been picked up, false otherwise</returns>
    public bool SetPickup(GameObject newPickup, bool status)
    {
        // Nothing in pickup
        if (pickup == null && !status)
        {
            pickup = newPickup;
            UpdatePickup();
            return true;
        }

        // Already picked up something and want to put it down
        else if (pickup != null && status)
        {
            pickup = null;
            UpdatePickup();
        }
        else{  // else statement only here for debugging
            Debug.Log("Cannot pick up while already holding item");
        }

        // All other cases
        return false;
    }
}
