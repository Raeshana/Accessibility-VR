using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform playerPos;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get rigidbody
        rb.freezeRotation = true; // Disable rotation for rigidbody
    }

    void Update() {
        MyInput();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput() {
        // Get player inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        // Calculate movement direction
        moveDirection = playerPos.forward * verticalInput + playerPos.right * horizontalInput;

        // Apply force to move rigidbody
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
