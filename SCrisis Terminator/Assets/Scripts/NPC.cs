using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable, IInteractable
{
    public void Interact()
    {
        Debug.Log($"Hello from {gameObject.name}");
    }
}
