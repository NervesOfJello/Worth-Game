using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Fields
    [SerializeField]
    float moveSpeed;

    //Variables
    float horizontalInput;
    float verticalInput;

    //Component References
    Rigidbody2D playerBody;

	// Use this for initialization
	void Start () 
	{
        playerBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        GetInput();
	}

    //Do Physics Here
    private void FixedUpdate()
    {
        Move();
    }

    //Recieve input values
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");
    }

    //Move the player
    private void Move()
    {
        playerBody.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }
}
