using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mouselook : MonoBehaviour
{
    public Transform player;
    private float mouseX, mouseY;
    public float mouseSensitivity = 200f;
    public float xRotation;

    public void Start()
    {
        player = GameObject.Find("player").transform;
        
        
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
