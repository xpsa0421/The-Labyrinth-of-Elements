using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public Slider mainSlider;

    public void setMaxCoolDown(int cooldown){
        mainSlider.maxValue = cooldown;
        mainSlider.value = cooldown;
    }

    public void setCurrentCoolDown(float cooldown){
        mainSlider.value = cooldown;
    }

    public void setActive(bool state){
        gameObject.SetActive(state);
    }
}
