using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    
    public PlayerHealth playerHealth;

    public void RestartGame()
    {
        playerHealth.ResetPlayerHealth();
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
