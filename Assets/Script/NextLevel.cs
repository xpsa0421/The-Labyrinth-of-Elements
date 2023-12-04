using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameOverMenu gameoverMenu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameObject.Find("item") == null)
            {   
                // if the game is over, redirect to main menu
                if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1){
                    gameoverMenu.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    return;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
        
    }
}
