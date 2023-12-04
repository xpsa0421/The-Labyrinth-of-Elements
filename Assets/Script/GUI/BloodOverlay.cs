using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodOverlay : MonoBehaviour
{

    private Image img;
    private bool fadeAway = true;
    private float fadeCD = 1.5f;
    private float currentCD = 0f;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = currentCD/fadeCD;
        if(fadeAway && currentCD < fadeCD){
            currentCD+=Time.deltaTime;
        }
        else{
            currentCD-=Time.deltaTime;
            fadeAway = false;
        }
        if(currentCD <= 0f){
            fadeAway = true;
        }
        img.color = new Color(1,1,1,alpha);
    }

}
