using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody), typeof(Collider))]
[DisallowMultipleComponent]

public class PhysicsMovement : MonoBehaviour
{

    GameplayControls controls;

    Rigidbody rb;

    [Range(0, 100)]
    public float jumpForce;
    [Range(0, 100)]
    public float gravity;

    [Range(1, 100)]
    public float moveForce;

    public bool isGrounded;

    public LayerMask groundLayer;

    float groundLayerIndex;


    private void OnEnable()
    {
        controls = InputManager.instance.gc;
        controls.Gameplay.Jump.performed += (_) => OnJump();
    }
    private void OnDisable()
    {
        controls.Gameplay.Jump.performed -= (_) => OnJump();
    }
    private void Start()
    {
        groundLayerIndex = Mathf.Log(groundLayer, 2);
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Move(controls.Gameplay.Move.ReadValue<Vector2>());
        if (!isGrounded)
            rb.AddForce(Vector3.down * gravity);
    }


    public void OnJump()
    {
        if (isGrounded)
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }




    Vector3 movement;
    void Move(Vector2 direction)
    {
        movement = transform.TransformDirection(new Vector3(direction.x * moveForce, movement.y, direction.y * moveForce));

        rb.AddForce(movement, ForceMode.Acceleration);
        Debug.DrawRay(transform.position, rb.velocity);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.layer == groundLayerIndex)
            isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == groundLayerIndex)
            isGrounded = false;
    }




}
