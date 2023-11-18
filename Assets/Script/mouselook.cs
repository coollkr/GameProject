using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mouselook : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float playerHeight = 2f; // Adjust based on character's height
    public Transform orientation;
    public Transform player;

    float xRotation;
    float yRotation;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X")  * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        
        // Rotate the camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // Rotate the character
        player.rotation = Quaternion.Euler(0,yRotation, 0);

        // Adjust the camera position to avoid clipping through the character
        Vector3 playerHeadPosition = player.position + Vector3.up * playerHeight;
        transform.position = playerHeadPosition + transform.forward * 0.75f; // Adjust the multiplier if needed
    }
}
