using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour {

    [SerializeField]
    public GameObject player;

    [SerializeField]
    AchievZone achievement;

    [SerializeField]
    bool isTreeCat;

    private Transform playerTransform;

    private SpriteRenderer sprite;

    float distance;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        playerTransform = player.transform;
        distance = Vector3.Distance(playerTransform.position, transform.position);

        if (achievement.isAchieved == true)
        {
            Follow();
            if (isTreeCat)
            {
                sprite.sortingLayerName = "NPCs";
            }
        }

	}


    private void Follow()
    {

        if (distance > 1)
        {
            GetComponent<NavMeshAgent2D>().destination = playerTransform.position;
        }

        
    }

}
