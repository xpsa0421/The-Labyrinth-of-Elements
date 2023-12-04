using UnityEngine;
using UnityEngine.Tilemaps;

public class HideableTile : MonoBehaviour
{
    Tilemap tiles;
    

    void Start(){
        tiles = GetComponent<Tilemap>();
    }

    // function called when the Player collides with other objects
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name == "Player"){        
            tiles.color = new Color(1.0f,1.0f,1.0f,0.4f);
        }
    }

    void OnTriggerExit2D(Collider2D obj){
        if(obj.gameObject.name == "Player"){
            tiles.color = new Color(1.0f,1.0f,1.0f,1.0f);

        }
    }
}
