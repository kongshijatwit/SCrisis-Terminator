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

    public void SetPickup(GameObject newPickup, bool status)
    {
        if (status) { pickup = newPickup; }
        else { pickup = null; }
        newPickup.GetComponent<MeshRenderer>().enabled = !status;
        UpdatePickup();
    }
}
