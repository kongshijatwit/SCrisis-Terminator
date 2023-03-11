using UnityEngine;
using System;

public class PickupManager : MonoBehaviour
{
    public static PickupManager instance;
    
    [SerializeField] private GameObject pickup = null;
    public event Action UpdatePickup = delegate { };

    private void Awake() 
    {
        instance = this;
    }

    public void SetPickup(GameObject newPickup)
    {
        pickup = newPickup;
        UpdatePickup();
    }
}
