using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievZone : MonoBehaviour, IComparable<AchievZone> {

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
    private int achievValue;

    public bool isAchieved = false;

    // Use this for initialization
    void Start () {
        originalTime = captureTime;
        achievText.text = achievName + ": " + (100 - ((captureTime/originalTime)*100)) + "%";
	}
	
	// Update is called once per frame
	void Update () {

		Achieved();

        if (isAchieved)
        {
            ListOfAchievementsScript.achievements.Add(this);
        }

	}


    public AchievZone(string Name, int Value)
    {
        Name = achievName;
        Value = achievValue;
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

    public int CompareTo(AchievZone other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return achievValue - other.achievValue;


    }
}
