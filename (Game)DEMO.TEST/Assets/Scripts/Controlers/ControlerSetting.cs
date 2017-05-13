using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlerSetting : MonoBehaviour {

   
    void Start ()
    {
        //if (!MenuMusic.GetMainMusic().is_mute())
        //{
        //    GameObject.Find("BMuteOn").GetComponent<Image>().enabled = false;
        //    GameObject.Find("BMuteOff").GetComponent<Image>().enabled = true;
        //}
        //else if (MenuMusic.GetMainMusic().is_mute())
        //{
        //    GameObject.Find("BMuteOn").GetComponent<Image>().enabled = true;
        //    GameObject.Find("BMuteOff").GetComponent<Image>().enabled = false;
        //}

        GameObject.Find("SliderMusic").GetComponent<Slider>().value = MenuMusic.GetMainMusic().getVolumeLevel();
        GameObject.Find("SliderSound").GetComponent<Slider>().value = ButtonClickSound.GetSounds().getVolumeLevel();
        GameObject.Find("SliderSound").GetComponent<Slider>().onValueChanged.AddListener(delegate { changeVolumeSound(); });
        GameObject.Find("SliderMusic").GetComponent<Slider>().onValueChanged.AddListener(delegate { changeVolumeMusic(); });
        GameObject.Find("BReturn").GetComponent<Button>().onClick.AddListener(PressReturn);

        GameObject.Find("BMuteOn").GetComponent<Button>().onClick.AddListener(PressMute);

        GameObject.Find("BMuteOff").GetComponent<Button>().onClick.AddListener(PressMute);

    }

    private void changeVolumeSound()
    {
        ButtonClickSound.GetSounds().changeVolume(GameObject.Find("SliderSound").GetComponent<Slider>().value);
    }
    private void changeVolumeMusic()
    {
        MenuMusic.GetMainMusic().changeVolume(GameObject.Find("SliderMusic").GetComponent<Slider>().value);
    }
    private void PressReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void PressMute()
    {
        //if no mute
        if (!MenuMusic.GetMainMusic().is_mute())
        {
            Debug.Log("BMuteOff");
            //do mute
            MenuMusic.GetMainMusic().changeMute();
            GameObject.Find("BMuteOn").GetComponent<Image>().enabled = true;
            GameObject.Find("BMuteOff").GetComponent<Image>().enabled = false;
            MenuMusic.GetMainMusic().setMute();
            ButtonClickSound.GetSounds().setMute();
        }
        else if (MenuMusic.GetMainMusic().is_mute())
        {
            Debug.Log("BMuteOn");
            MenuMusic.GetMainMusic().changeMute();
            GameObject.Find("BMuteOn").GetComponent<Image>().enabled = false;
            GameObject.Find("BMuteOff").GetComponent<Image>().enabled = true;
            MenuMusic.GetMainMusic().unsetMute();
            ButtonClickSound.GetSounds().unsetMute();
        }

    }
}




