using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private readonly float speed = 700f;
    private readonly float maxSpeed = 2.5f;

    private bool canMove;
    private float hInput;
    private float vInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
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
        if (canMove) rb.AddForce(speed * Time.fixedDeltaTime * moveDir);
        rb.velocity = new(clampX, 0, clampZ);
    }

    private void StopMoving() => canMove = false;

    private void StartMoving() => canMove = true;
}