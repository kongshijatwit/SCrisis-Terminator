using UnityEngine;

/// <summary>
/// Draws a raycast from the center of the screen
/// Used to handle hovering over a specified object with the IRaycastable interface
/// </summary>
public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private InteractionPromptUI _InteractionPromptUI;
    private readonly float rayDistance = 2f;

    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            // Everything that happens when the raycast hits something
            hit.transform.GetComponent<IRaycastable>().HandleRaycast(this);
            if (!_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.SetUp(hit.transform.GetComponent<Iinteractable>().InteractionPrompt);
        }
        else
        {
            // Everything that happens when the raycast no long hits anything
            _InteractionPromptUI.Close();
        }

        // Draws a ray in the scene view - remember to turn on gizmos
        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }
}
