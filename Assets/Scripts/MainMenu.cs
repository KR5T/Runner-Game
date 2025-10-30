using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
    }
    public void ReloadLevel(){
        Time.timeScale = 1f; //temp solition. there is gonna be singleton for this
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex-1;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
