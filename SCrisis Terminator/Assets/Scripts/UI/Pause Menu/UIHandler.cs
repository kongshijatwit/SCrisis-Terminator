using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) TogglePauseMenu();
    }

    public void TogglePauseMenu() => pauseMenu.SetActive(MouseVisible());

    // Return value depends cursor visibility
    private bool MouseVisible()
    {
        var playerCamera = Camera.main.GetComponent<PlayerCamera>();
        Camera.main.GetComponent<PlayerCamera>().enabled = !playerCamera.enabled;
        Cursor.lockState = playerCamera.enabled ? CursorLockMode.Locked : CursorLockMode.None;
        return Cursor.visible = !playerCamera.enabled;
    }
}
