using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Serialized Fields
    [Header("Component References")]
    [SerializeField]
    Slider TimerSlider;
    [SerializeField]
    Camera cameraObject;
    [SerializeField]
    Player playerObject;

    [Header("Camera Settings")]
    [SerializeField]
    float startingCamSize;
    [SerializeField]
    float finalCamSize;

    [Header("Player Settings")]
    [SerializeField]
    float startSpeed;
    [SerializeField]
    float endSpeed;

    [Header("Game Settings")]
    [SerializeField]
    float GameTime;
    [SerializeField]
    float updateInterval;


    //variables
    float maxTime;
    float secondsPast;

    //List for storing Achievements
    List<string> Achievements;


	// Use this for initialization
	void Start () 
	{
        maxTime = GameTime;
        SetInitialConditions();
        StartCoroutine(GameTimer());
	}
	
    //sets starting speed and zoom
    void SetInitialConditions()
    {
        playerObject.moveSpeed = startSpeed;
        cameraObject.orthographicSize = startingCamSize;
    }

	// Update is called once per frame
	void Update () 
	{
		UpdateCameraZoom();
        UpdatePlayerSpeed();
	}

    //Updates camera zoom according to time past, zooming out over time
    void UpdateCameraZoom()
    {
        float cameraDifference = (finalCamSize - startingCamSize) * (secondsPast / maxTime);

        cameraObject.orthographicSize = startingCamSize + cameraDifference;
    }

    void UpdatePlayerSpeed()
    {
        float speedDifference = (startSpeed - endSpeed) * (secondsPast / maxTime);

        playerObject.moveSpeed = startSpeed - speedDifference;
    }

    //updates the fill of the progress bar
    void UpdateTimeSlider()
    {
        TimerSlider.value = secondsPast / (maxTime - 1);
    }

    //Coroutines

    //ticks down time left, increments seconds past, sets the time slider, and navigates to the end page when the timer runs out
    IEnumerator GameTimer()
    {
        while (GameTime > 0)
        {
            GameTime -= updateInterval;
            secondsPast += updateInterval;
            yield return new WaitForSeconds(updateInterval);
            UpdateTimeSlider();
            Debug.Log(GameTime + "seconds left");
        }
        SceneManager.LoadScene("EndScene");
    }

}
