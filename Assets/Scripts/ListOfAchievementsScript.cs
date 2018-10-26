using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfAchievementsScript  {

    //https://unity3d.com/learn/tutorials/modules/intermediate/scripting/lists-and-dictionaries
    // https://unity3d.com/learn/tutorials/topics/scripting/statics
    // https://gamedev.stackexchange.com/questions/110958/unity-5-what-is-the-proper-way-to-handle-data-between-scenes


    public static List<AchievZone> achievements = new List<AchievZone>();

	// Use this for initialization
	static void Start () {
		
	}
	
	// Update is called once per frame
	static void Update () {
		
	}

    public static void AddAchievement(AchievZone newAchievement)
    {
        achievements.Add(newAchievement);

    }



}
