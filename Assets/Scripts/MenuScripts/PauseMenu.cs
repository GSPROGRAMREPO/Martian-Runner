using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenuLevel;

    public GameObject thePauseMenu;


    public void PauseGame(){
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
    }


    public void RestartGame(){
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
        thePauseMenu.SetActive(false);
    }

    public void QuitToMain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
        thePauseMenu.SetActive(false);  
    }

}
