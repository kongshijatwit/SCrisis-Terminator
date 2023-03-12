using UnityEngine;

/// <summary>
/// Controls the player's movement using the old input system
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private DialogueController dc;

    private readonly float speed = 700f;
    private readonly float maxSpeed = 2.5f;

    private float hInput;
    private float vInput;

    private void Start()
    {
        dc = GetComponent<DialogueController>();
        rb = GetComponent<Rigidbody>();
        dc.OnConversationStarted += StopMoving;
        dc.OnConversationEnded += StartMoving;
        rb.isKinematic = false;
    }

    void Update()
    {
        if (!rb.isKinematic)
        {
            hInput = Input.GetAxis("Horizontal");
            vInput = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        float clampX = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float clampZ = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        Vector3 moveDir = gameObject.transform.forward * vInput + gameObject.transform.right * hInput;
        rb.AddForce(speed * Time.fixedDeltaTime * moveDir);
        rb.velocity = new(clampX, 0, clampZ);
    }

    private void StopMoving()
    {
        rb.isKinematic = true;
    }

    private void StartMoving()
    {
        rb.isKinematic = false;
    }

    private void OnDisable()
    {
        dc.OnConversationStarted -= StopMoving;
        dc.OnConversationEnded -= StartMoving;
    }
}