using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private readonly Vector3 offset = new(0, 1f, 0);

    [SerializeField] float sensX = 1000f;
    [SerializeField] float sensY = 1000f;

    private float xRotation;
    private float yRotation;

    private void Start() => HideMouse();

    private void Update()
    {
        // Get mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Calculate mouse positions
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Don't want to move camera while mouse is visible (i.e, If dialogue box is open)
        if (!Cursor.visible)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        Debug.Log(Cursor.visible);
    }

    // LateUpdate is usually synonomous with camera movement handling
    void LateUpdate() => transform.position = player.transform.position + offset;

    #region Helper Functions
    private void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) HideMouse();
    }
    #endregion
}
