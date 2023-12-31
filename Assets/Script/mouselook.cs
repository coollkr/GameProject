using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is to change the camera position based on your mouse.
public class mouselook : MonoBehaviour
{
    public Transform player;
    public Transform characterModel; 
    private float mouseX, mouseY;
    public float mouseSensitivity = 200f;
    public float xRotation;
    public bool followCharacterModel = false; 

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("No player component found.");
        }
    }

    void Update()
    {
        if (followCharacterModel && characterModel != null)
        {
            FollowCharacterModel();
        }
        else
        {
            PlayerControlledLook();
        }
    }
    
    
    //rotation the camera based on the mouse X and Y.
    private void PlayerControlledLook()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        
        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
    
    //method to follow main character.
    private void FollowCharacterModel()
    {
        Vector3 directionToCharacterModel = characterModel.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToCharacterModel);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * mouseSensitivity);
    }

    public void SetFollowCharacterModel(bool state)
    {
        followCharacterModel = state;
    }
}

