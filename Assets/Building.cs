using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {


    SpriteRenderer spriteR;

	// Use this for initialization
	void Start () {
        spriteR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {


		
	}


    public void OnTriggerStay2D(Collider2D collision)
    {

            spriteR.enabled = false;
        

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteR.enabled = true;
    }



}
