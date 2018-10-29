using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListOfAchievementsScript : MonoBehaviour {

    //https://unity3d.com/learn/tutorials/modules/intermediate/scripting/lists-and-dictionaries
    // https://unity3d.com/learn/tutorials/topics/scripting/statics
    // https://gamedev.stackexchange.com/questions/110958/unity-5-what-is-the-proper-way-to-handle-data-between-scenes


    public static List<AchievZone> achievements = new List<AchievZone>();

    public GameObject Grave;
    Text text;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start() {
        Scene currentScene = SceneManager.GetActiveScene();

        Grave = GameObject.FindGameObjectWithTag("Grave");

        if (currentScene.name == "EndScene")
        {
            PrintAchievements();
        }

    }

    // Update is called once per frame
    void Update() {

    }

    public void AddAchievement(AchievZone newAchievement)
    {
        achievements.Add(newAchievement);

    }

    public void PrintAchievements()
    {
        achievements.Sort();
        if (text != null)
        {
            text = Grave.GetComponent<Text>();
            foreach (AchievZone x in achievements)
            {
                text.text = x.name;
            }
        }
    }



}
