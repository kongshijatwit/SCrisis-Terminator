using UnityEngine;

/// <summary>
/// Attach to a camera to have it follow the target by its Transform
/// Mostly to be used on the player
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    // Player fields and offset to set camera position
    [SerializeField] private Transform player;
    private DialogueController dc;
    private readonly Vector3 offset = new(0, 1.3f, 0);

    // Mouse movement and sensitivity
    private bool mouseMoving;
    [SerializeField] float sensX = 1000f;
    [SerializeField] float sensY = 1000f;

    // Mouse rotation
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        dc = player.GetComponent<DialogueController>();
        dc.OnConversationStarted += ShowMouse;
        dc.OnConversationEnded += HideMouse;
        HideMouse();
    }

    private void Update()
    {
        // Get mouse inputs and adjust sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Calculate and clamp mouse positions. Make sure player can't look over -90 and 90 degrees
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // When the mouse is visible, no player controls
        if (mouseMoving)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    // LateUpdate is usually synonomous with camera movement handling
    void LateUpdate() => transform.position = player.transform.position + offset;

    private void OnDisable()
    {
        dc.OnConversationStarted -= ShowMouse;
        dc.OnConversationEnded -= HideMouse;
    }

    #region Helper Functions for Mouse States
    private void ShowMouse()
    {
        mouseMoving = false;
    }

    private void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseMoving = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) HideMouse();
    }
    #endregion
}
