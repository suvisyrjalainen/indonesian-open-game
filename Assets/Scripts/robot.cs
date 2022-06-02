using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
	public CharacterController controller;
	
	private float HorizontalMovement = 0f;
	private float VerticalMovement = 0f;
	private float HorizontalMouseMovement = 0f;
	
	private float VerticalSpeed = 1f;
	
	public Animator MyAnimator;
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		//moving commands
		HorizontalMovement = Input.GetAxis("Horizontal");
		VerticalMovement = Input.GetAxis("Vertical") * VerticalSpeed;
		Vector3 speed = new Vector3(HorizontalMovement, 0, VerticalMovement);
		
		//turning commands
		HorizontalMouseMovement += Input.GetAxis("Mouse X") * 3;
		transform.localRotation = Quaternion.Euler(0, HorizontalMouseMovement, 0);
		speed = transform.rotation * speed;
		
		if(VerticalMovement > 0){
			MyAnimator.SetBool("WalkF", true);
			
			if (Input.GetKeyDown("left shift"))
            {
                MyAnimator.SetBool("RunF", true);
                VerticalSpeed = 5f;
                MyAnimator.SetBool("WalkF", false);
            }
		}
		else{
			MyAnimator.SetBool("WalkF", false);
			MyAnimator.SetBool("RunF", false);
            VerticalSpeed = 1f;
		}
		
		
		//final movement command
		controller.Move(speed * Time.deltaTime);
        
    }
}
