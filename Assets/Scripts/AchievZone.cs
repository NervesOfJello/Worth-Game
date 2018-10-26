using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievZone : MonoBehaviour {

    [SerializeField]
    private float captureTime;
    private float originalTime;

    private bool insideZone;

    [SerializeField]
    private Collider2D playerDetectTrigger;
    private Collider2D[] playerHitDetectionResults = new Collider2D[16];

    [SerializeField]
    private ContactFilter2D playerContactFilter;

    [SerializeField]
    private SpriteRenderer self;

    [SerializeField]
    public Text achievText;

    [SerializeField]
    private string achievName;

    [SerializeField]
    private string achievValue;

    public bool isAchieved = false;

    // Use this for initialization
    void Start () {
        originalTime = captureTime;
        achievText.text = achievName + ": " + (100 - ((captureTime/originalTime)*100)) + "%";
	}
	
	// Update is called once per frame
	void Update () {

		Achieved();

	}



    private void Achieved()
    {

        int capturePercent = (int)((captureTime / originalTime) * 100);

        insideZone = playerDetectTrigger.OverlapCollider(playerContactFilter, playerHitDetectionResults) > 0;

        if (insideZone && captureTime >= 0)
        {
            captureTime -= Time.deltaTime;
            achievText.text = achievName + ": " + (100 - (capturePercent)) + "%";
        }

        if (captureTime <= 0)
        {
            self.color = Color.green;
            achievText.text = achievName + ": 100%";
            isAchieved = true;
        }

    }




}
