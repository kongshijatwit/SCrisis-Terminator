using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerControllerTest : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5f;
    private float gravity = 9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 moveDir = gameObject.transform.forward * vInput + gameObject.transform.right * hInput;
        controller.Move(moveDir * Time.deltaTime * speed);
        controller.Move(Vector3.down * Time.deltaTime * gravity);
    }
}