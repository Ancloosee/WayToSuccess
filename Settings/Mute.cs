using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {


    public void Awake()
    {
        if (!MenuMusic.GetMainMusic().is_mute())
        {
            GameObject.Find("MuteOn").GetComponent<Image>().enabled = false;
            GameObject.Find("MuteOff").GetComponent<Image>().enabled = true;
            }
        else if (MenuMusic.GetMainMusic().is_mute())
        {
            GameObject.Find("MuteOn").GetComponent<Image>().enabled = true;
            GameObject.Find("MuteOff").GetComponent<Image>().enabled = false;
        }
    }

    public  void OnMouseDown()
    {
        //if no mute
		if(!MenuMusic.GetMainMusic().is_mute())
        {
            Debug.Log("MuteOff");
            //do mute
            MenuMusic.GetMainMusic().changeMute();
            GameObject.Find("MuteOn").GetComponent<Image>().enabled = true;
            GameObject.Find("MuteOff").GetComponent<Image>().enabled = false;
            MenuMusic.GetMainMusic().setMute();
            ButtonClickSound.GetSounds().setMute();
        }
        else if(MenuMusic.GetMainMusic().is_mute())
        {
            Debug.Log("MuteOn");
            MenuMusic.GetMainMusic().changeMute();
            GameObject.Find("MuteOn").GetComponent<Image>().enabled = false;
            GameObject.Find("MuteOff").GetComponent<Image>().enabled = true;
            MenuMusic.GetMainMusic().unsetMute();
            ButtonClickSound.GetSounds().unsetMute();
        }

	}
}
