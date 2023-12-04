using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int level;
    public int health = 20;
    public int maxHealth = 20;

    public void SaveLevel(){
        this.level = SceneManager.GetActiveScene().buildIndex;
        
    }

    public void SavePlayer(){
        
        SaveSystem.SavePlayer(this);
    }
    
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        if(data != null){
            this.level = data.level;
            this.health = data.health;
        }

    }
}
