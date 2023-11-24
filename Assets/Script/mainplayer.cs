using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainplayer : MonoBehaviour
{
    public float moveSpeed;
    public float RunSpeed = 10f;
    public float WalkSpeed = 2f;
    public float RotateSpeed;
    
    public CharacterController controller;
    public Vector3 moveDirection;
    private Vector3 velocity;
    
    public bool isGrounded;
    public float groundCheckDistance = 0.4f;
    public float gravity = -9.8f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    
    
    
    
    private Animator animator;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        controller = GetComponent<CharacterController>();
        
        groundMask = LayerMask.GetMask("ground");
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInChildren<Animator>();
        
        
    }
    
    
    void Update()
    {
        //call move function
        Move();
        
    }
    
    private void Move()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }

       
        var moveZ = Input.GetAxis("Vertical");
        var moveX = Input.GetAxis("Horizontal");
        
        

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        
        
        
        if (isGrounded)
        {
            

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
            
                Walk();
                
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
            
                Run();
                
            }
            

            if (Input.GetButtonDown("Jump"))
            {
                
                Jump();
                
            }
            
            
            if (moveDirection == Vector3.zero && !Input.GetButtonDown("Jump"))
            {
                idle();
            }
            
        }

       
        // if player is not on the ground.
        



        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);
        
       
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        

    }
    
    
    //movement function or change speed when walking or Running.
    private void idle()
    {
        animator.SetFloat("speed", 0,0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        moveSpeed = WalkSpeed;
        animator.SetFloat("speed", 0.5f,0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = RunSpeed;
        animator.SetFloat("speed", 1, 0.1f, Time.deltaTime);
    }
    
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    

}
