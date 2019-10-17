using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour{

    public string levelToLoad;

    public void PlayGame(){
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
