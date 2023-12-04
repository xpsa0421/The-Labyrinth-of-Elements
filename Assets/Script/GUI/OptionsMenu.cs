using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    public AudioMixer audioMixer;


    public void SetVolume(float volume){
        // Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);

    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void BackToScene(){
        gameObject.SetActive(false);
    }

}
