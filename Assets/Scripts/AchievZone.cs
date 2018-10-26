using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievZone : MonoBehaviour {

    [SerializeField]
    private float captureTime;

    private bool insideZone;

    [SerializeField]
    private Collider2D playerDetectTrigger;
    private Collider2D[] playerHitDetectionResults = new Collider2D[16];

    [SerializeField]
    private ContactFilter2D playerContactFilter;

    [SerializeField]
    private GameObject self;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        insideZone = playerDetectTrigger.OverlapCollider(playerContactFilter, playerHitDetectionResults) > 0;

        if (insideZone)
        {
            captureTime -= Time.deltaTime;
        }

        if (captureTime <= 0)
        {
            
        }

		
	}
}
