using UnityEngine;
using System;

public class PickupManager : MonoBehaviour
{
    public static PickupManager instance;
    public GameObject pickup = null;
    public event Action UpdatePickup = delegate { };

    private void Awake() 
    {
        instance = this;
    }

    /// <summary>
    /// Handles the picking up of GameObjects
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
        else{
            Debug.Log("Cannot pick up while already holding item");
        }

        // All other cases
        return false;
    }
}
