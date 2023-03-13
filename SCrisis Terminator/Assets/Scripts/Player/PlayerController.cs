using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private DialogueController dialogueController;
    private float speed = 5f;
    private float gravity = 9.81f;
    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        dialogueController = GetComponent<DialogueController>();

        dialogueController.OnConversationStarted += StopMoving;
        dialogueController.OnConversationEnded += StartMoving;
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 moveDir = gameObject.transform.forward * vInput + gameObject.transform.right * hInput;
        
        if(!canMove)
        {
            controller.velocity.Set(0, 0, 0);
            return;
        }
        controller.Move(moveDir * Time.deltaTime * speed);
        controller.Move(Vector3.down * Time.deltaTime * gravity);
        
    }

    private void StartMoving()
    {
        canMove = true;
    }

    private void StopMoving()
    {
        canMove = false;
    }

    private void OnDisable() 
    {
        dialogueController.OnConversationStarted -= StopMoving;
        dialogueController.OnConversationEnded -= StartMoving;
    }
}