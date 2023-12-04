using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject LoadButton;
    void Start(){
        LoadButton = GameObject.Find("LoadGameButton");
        if(SaveSystem.LoadPlayer() == null){
            LoadButton.SetActive(false);
        }
    }

    public void LoadGame(){
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.level);
    }
    
    public void PlayGame()
    {
        Debug.Log("Play Level "+ SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()

    {
        Debug.Log("Back");
        SceneManager.LoadScene(0);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
