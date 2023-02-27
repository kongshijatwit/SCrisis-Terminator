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
            SpeedControl();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDir = gameObject.transform.forward * vInput + gameObject.transform.right * hInput;
        rb.AddForce(speed * Time.fixedDeltaTime * moveDir.normalized, ForceMode.Force);
    }

    private void SpeedControl()
    {
        float maxVelX = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float maxVelZ = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        rb.velocity = new(maxVelX, 0, maxVelZ);
    }

    private void StopMoving() => canMove = false;

    private void StartMoving() => canMove = true;
}