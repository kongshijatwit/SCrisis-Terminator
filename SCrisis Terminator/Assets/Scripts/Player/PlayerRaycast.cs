using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private readonly float rayDistance = 2f;

    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            hit.transform.GetComponent<IRaycastable>().HandleRaycast(this);
        }

        // Draws a ray in the scene view - remember to turn on gizmos
        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }
}
