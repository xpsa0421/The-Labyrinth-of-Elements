using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
