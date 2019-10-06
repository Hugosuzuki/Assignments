using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Vector3 directionV;
    public Vector3 directionH;
    public float speed;
    public float jumpForce;
    public Collider Collider;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 5.0f;
        speed = 10.0f;
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
    }

    // Function to get directional input for WASD to replace Input.GetAxis
    Vector3 GetDirection()
    {
        directionV = new Vector3(0.0f, 0.0f, 0.0f);
        directionH = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            directionV = (transform.forward).normalized;
        }

        if (Input.GetKey(KeyCode.S))
        {
            directionV = (-transform.forward).normalized;
        }

        if (Input.GetKey(KeyCode.A))
        {
            directionH = (-transform.right).normalized;
        }

        if (Input.GetKey(KeyCode.D))
        {
            directionH = transform.right.normalized;
        }

        return directionV + directionH;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, Collider.bounds.extents.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate/Look with Mouse
        transform.Rotate(0, Input.GetAxis("Mouse X") * 90 * Time.deltaTime, 0);

        // Move 
        Rigidbody.MovePosition(transform.position + GetDirection() * speed * Time.deltaTime);
                
        // Jump with Space Bar
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
