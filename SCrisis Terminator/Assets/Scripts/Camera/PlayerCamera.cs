using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private DialogueController dc;
    private readonly Vector3 offset = new(0, 1f, 0);

    private bool mouseMoving;
    [SerializeField] float sensX = 1000f;
    [SerializeField] float sensY = 1000f;

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

        // Calculate and clamp mouse positions
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

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
