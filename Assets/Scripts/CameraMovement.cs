using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] 
    private float senX;
    [SerializeField] 
    private float senY;

    [SerializeField] 
    private Transform playerPos;

    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the middle of screen
        Cursor.visible = false; // Hides cursor
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;
        
        // Adjust rotations
        rotY += mouseX;
        rotX -= mouseY;

        // Clamp rotations so player cannot look more than 90 degrees
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        // Apply rotations to camera and player
        transform.rotation = Quaternion.Euler(rotX, rotY, 0); // Rotate camera
        playerPos.rotation = Quaternion.Euler(0, rotY, 0); // Rotate player
    }
}
