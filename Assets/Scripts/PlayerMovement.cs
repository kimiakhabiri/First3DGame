using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private Rigidbody rb;
    private BoxCollider coll;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float MoveSpeed = 8f;
    [SerializeField] private float JumpForce = 7f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");
        rb.velocity = new Vector3 (dirX * MoveSpeed, rb.velocity.y, dirZ * MoveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded()){
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity   = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, .1f, Ground);
    }
}
