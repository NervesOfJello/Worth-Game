using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    private Slider zoneSlider;

    [SerializeField]
    private Image self;

    [SerializeField]
    public Text achievText;

    [SerializeField]
    public string achievName;

    [SerializeField]
    private int achievValue;

    public bool isAchieved = false;


    public static List<AchievZone> achievements = new List<AchievZone>();


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    // Use this for initialization
    void Start () {
        originalTime = captureTime;

        achievText.text = achievName + ": " + (100 - ((captureTime/originalTime)*100)) + "%";

        zoneSlider.value = 0;
    }
	
	// Update is called once per frame
	void Update () {

		Achieved();

        if (isAchieved)
        {
            achievements.Add(this);
        }

	}

   
    

    private void Achieved()
    {

        int capturePercent = (int)((captureTime / originalTime) * 100);

        zoneSlider.value = (100 - capturePercent);

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
    public void AddAchievement(AchievZone newAchievement)
    {
        achievements.Add(newAchievement);

    }



}
