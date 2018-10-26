using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //Fields
    [SerializeField]
    public float moveSpeed;

    //Variables
    float horizontalInput;
    float verticalInput;

    //Component References
    [SerializeField]
    Text headsUpText;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AchievZone>() != null)
        {
            headsUpText.text = collision.gameObject.GetComponent<AchievZone>().achievText.text;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        headsUpText.text = "";
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
