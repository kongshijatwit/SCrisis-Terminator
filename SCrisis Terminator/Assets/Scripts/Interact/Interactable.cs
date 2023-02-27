using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    private IInteractable interactable;
    private bool inRange;

    private void Start()
    {
        interactable = GetComponent<IInteractable>();
        inRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            interactable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other) => inRange = true;

    private void OnTriggerExit(Collider other) => inRange = false;

}
