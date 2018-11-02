using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour {

    [SerializeField]
    public GameObject player;

    public Transform playerTransform;

    float distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerTransform = player.transform;
        distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance > 5)
        {
           // GetComponent<NavMeshAgent2D>
        }


	}
}
