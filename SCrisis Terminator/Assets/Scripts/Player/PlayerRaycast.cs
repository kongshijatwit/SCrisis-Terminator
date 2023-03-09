using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private readonly float rayDistance = 2f;

    void Update()
    {
        Vector3 origin = gameObject.transform.position;
        Vector3 direction = gameObject.transform.forward;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            hit.transform.GetComponent<IRaycastable>().HandleRaycast(this);
        }
        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }
}
