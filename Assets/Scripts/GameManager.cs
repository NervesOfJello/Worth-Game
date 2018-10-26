using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Serialized Fields
    [SerializeField]
    Slider TimerSlider;

    [SerializeField]
    int GameTime;

    //variables
    float maxTime;
    float secondsPast;


	// Use this for initialization
	void Start () 
	{
        maxTime = GameTime;
        StartCoroutine(GameTimer());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    //updates the fill of the progress bar
    void UpdateTimeSlider()
    {
        if ((secondsPast / (maxTime - 1)) > 1)
        {
            TimerSlider.value = secondsPast / (maxTime - 1);
        }
        else
        {
            TimerSlider.value = 1;
        }
        
    }

    //Coroutines

    //ticks down time left, increments seconds past, sets the time slider, and navigates to the end page when the timer runs out
    IEnumerator GameTimer()
    {
        while (GameTime > 0)
        {
            GameTime--;
            secondsPast++;
            yield return new WaitForSeconds(1);
            UpdateTimeSlider();
            Debug.Log(GameTime + "seconds left");
        }
        SceneManager.LoadScene("EndScene");
    }

}
