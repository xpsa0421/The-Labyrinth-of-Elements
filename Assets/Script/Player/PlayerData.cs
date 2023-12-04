using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int level;
    public int health;
    public int maxHealth;
    

    public PlayerData(Player player){
        level = player.level;
        health = player.health;
        maxHealth = player.maxHealth;
    }
}
