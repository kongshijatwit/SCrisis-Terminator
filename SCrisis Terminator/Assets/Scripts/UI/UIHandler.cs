using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var playerCamera = Camera.main.GetComponent<PlayerCamera>();
            Camera.main.GetComponent<PlayerCamera>().enabled = !playerCamera.enabled;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !playerCamera.enabled;

            pauseMenu.SetActive(!playerCamera.enabled);
        }
    }
}
