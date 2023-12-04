using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider mainSlider;

    public void SetMaxHealth(int health)
    {
        mainSlider.maxValue = health;
        mainSlider.value = health;
    }

    public void SetHealth(int health)
    {
        mainSlider.value = health;
    }

}
