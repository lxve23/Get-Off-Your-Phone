using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = verticalInput * camForward;
        Vector3 rightRelative = horizontalInput * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        rb.velocity = new Vector3(moveDir.x, 0, moveDir.z);

        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    public void SetSpeed(float speed) {
        moveSpeed = speed;
    }
}