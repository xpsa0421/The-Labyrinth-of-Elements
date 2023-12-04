using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void OpenOptions(){
        OptionsMenu.SetActive(true);
    }
}
