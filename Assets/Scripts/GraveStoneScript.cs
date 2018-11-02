using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveStoneScript : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start () {




            PrintAchievements();
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrintAchievements()
    {
        AchievZone.achievements.Sort();

            text = this.GetComponent<Text>();
            foreach (AchievZone x in AchievZone.achievements)
            {
            if (text.text == "")
            {
                text.text = x.achievName;
                break;
            }
            else
            {
                text.text += "and " + x.achievName;
            }
                
            }
        
    }

}
