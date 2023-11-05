/*
 * this is assignment for CSCI 4168 Game design
 *
 * Name: Kairui Liang B00861227
 *
 * this a camera follow script.
 *
 * this script will help camera follow the character without cinemachine.
 *
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform targetObject;

    public Vector3 camerOffset;

    private void Awake()
    {
        //find player to track
        targetObject = GameObject.Find("maincharacter").transform;
    }

    void Start()
    {
        //the distance between character and camera, and it cannot be changed.
        camerOffset = transform.position - targetObject.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetObject != null)
        {
            Vector3 newPosition = targetObject.transform.position + camerOffset;
            transform.position = newPosition;
        }
        
    }
}
