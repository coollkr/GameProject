using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controll : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Collision Detected with: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)

    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            
            animator.SetTrigger("attack");
        }
    }

    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            animator.SetTrigger("attack");
        }
    }
}
