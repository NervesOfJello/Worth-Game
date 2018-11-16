using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //editor-accessible field names
    [SerializeField]
    private string levelSceneName;
    
    //button methods
    public void StartButtonClicked()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    public void ExitButtonClicked()
    {
        Debug.Log("Exiting Application...");
        Application.Quit();
    }
}
