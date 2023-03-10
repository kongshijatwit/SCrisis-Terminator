using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private readonly float rayDistance = 2f;

    void Update()
    {
        Vector3 origin = playerCamera.transform.position - new Vector3(0, 1f, 0);
        Vector3 direction = playerCamera.transform.forward;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            hit.transform.GetComponent<IRaycastable>().HandleRaycast(this);
        }

        // Draws a ray in the scene view - remember to turn on gizmos
        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }
}
