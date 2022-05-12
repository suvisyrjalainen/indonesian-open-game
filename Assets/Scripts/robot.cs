using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
	public CharacterController controller;
	
	private float HorizontalMovement = 0f;
	private float VerticalMovement = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		
		HorizontalMovement = Input.GetAxis("Horizontal");
		VerticalMovement = Input.GetAxis("Vertical");
		
		Vector3 speed = new Vector3(HorizontalMovement, 0, VerticalMovement);
		
		controller.Move(speed * Time.deltaTime);
        
    }
}
