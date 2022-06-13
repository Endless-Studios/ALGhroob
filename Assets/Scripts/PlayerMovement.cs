using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bool isSprinting = false;
	public float sprintingMultiplier;
	

	public CharacterController controller;
	
	public float crouchingHeight =1.25f;
	public float standingHeight =1.8f;
	public bool isCrouching = false;
	public float crouchingMultiplier;
    
	public float speed=9f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
	
	public Transform groundCheck;
	public float groundDistance=0.4f;
	public LayerMask groundMask;
    
	Vector3 velocity;
	bool isGrounded;
	
	public bool isWalking=false;
    
	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetButtonDown("Cancel")) {Application.Quit();}
		
		isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
		
		if(isGrounded && velocity.y<0)
		{
			velocity.y= -2f;
		}
		
		
		float x = Input.GetAxis("Horizontal"); 
		float z = Input.GetAxis("Vertical"); 
       
		
		
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y=Mathf.Sqrt(jumpHeight*-2f*gravity);
		}
		
		if(Input.GetKey(KeyCode.LeftShift) && isCrouching==false)
		{
			isSprinting=true;
		}
		else
		{
			isSprinting=false;
		}
		
		Vector3 move = transform.right*x+transform.forward*z;
       
		if (Input.GetKeyDown(KeyCode.C))
		{
			if(!isCrouching)
			{
				isCrouching = true;
			}
			else
			{
				isCrouching= false;
	    		
			}
		}
		
		
		if(isSprinting)
		{
			move *= sprintingMultiplier;
		}
		
		if(isCrouching)
		{
			controller.height = crouchingHeight;
			move *=crouchingMultiplier;
		}
		else
		{
			controller.height = standingHeight;
		}
		
		if (move.x!=0||move.z!=0){
			isWalking=true;
		}
		else{
			isWalking =false;
		}
		
		controller.Move(move * speed * Time.deltaTime);
		
		velocity.y += gravity * Time.deltaTime;
       
		controller.Move(velocity * Time.deltaTime);
       
	}
}
