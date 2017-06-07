using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///*This is abstract class for controll all music and sound in game */
//abstract public class Sounds:MonoBehaviour
//{
//    /*
//     *Play- for play any music or sounds
//     * Stop- for stop any music or sounds
//     * ChangeVolumeDown- for make music volume or sound volume less
//     * ChangeVolumeUp- for make music volume or sound volume more
//    */
//    abstract public void Play();
//    abstract public void Stop();
//    abstract public void ChangeVolumeDown();
//    abstract public void ChangeVolumeUp();

//}


//class MenuMusic:Sounds
//{
//    private AudioSource MainMusic;

//    public MenuMusic()
//    {
//        Awake();
//       // initialisationMusic();
//    }
//    public void Awake()
//    {
//        initialisationMusic();
//    }
//    public override void Play()
//    {
//        MainMusic.Play();
//    }
//    public override void Stop()
//    {
//        MainMusic.Stop();
//    }
//    public override void ChangeVolumeDown()
//    {
//        MainMusic.volume -= 0.01f;
//    }
//    public override void ChangeVolumeUp()
//    {
//        MainMusic.volume += 0.01f;
//    }
//    private void initialisationMusic()
//    {
//        if (!MainMusic)
//            MainMusic = GameObject.Find("MusicMainMenu").GetComponent<AudioSource>();
//        Debug.Log("MenuMusic constructor worked");
//    }


//}

//class ButtonClickSound:Sounds
//{
//    private AudioSource ButtonClick;


//    public ButtonClickSound()
//    {
//         initializationSound();
//        // Awake();
//        // initializationSound();
//    }
//    public void Awake()
//    {
//       initializationSound();
//    }
//    public override void Play()
//    {
//        ButtonClick.Play();
//    }
//    public override void Stop()
//    {
//        ButtonClick.Stop();
//    }
//    public override void ChangeVolumeDown()
//    {
//        ButtonClick.volume -= 0.01f; 
//    }
//    public override void ChangeVolumeUp()
//    {
//        ButtonClick.volume += 0.01f;
//    }
//    private void initializationSound()
//    {

//        ButtonClick = GameObject.Find("ButtonClickSounds").GetComponent<AudioSource>();
//        Debug.Log("Sound initiasated");

//    }
//}
/*This class for sound which plaing when we press any button*/
class ButtonClickSound
{
    private static ButtonClickSound sound;
    private static AudioSource ButtonClick;
    static public ButtonClickSound GetSounds()
    {
        if (sound == null)
            sound = new ButtonClickSound();
        return sound;
    }
    private ButtonClickSound()
    {
        initializationSound();
    }
    private void initializationSound()
    {

        ButtonClick = GameObject.Find("ButtonClickSounds").GetComponent<AudioSource>();
        
        Debug.Log("Sound initiasated");

    }
    public  void play()
    {
        initializationSound();
        ButtonClick.Play();
    }
    public  void stop()
    {
        ButtonClick.Stop();
    }
    public void setMute()
    {
        ButtonClick.mute = true;
    }
    public void unsetMute()
    {
        ButtonClick.mute = false;
    }

    public void changeVolume(float level)
    {
       
        ButtonClick.volume = level;
    }

    public float getVolumeLevel()
    {
        return ButtonClick.volume;
    }
}
/*
 * This class for music which playing in main menu
 * This a SINGLETONE class
  */
class MenuMusic 
{
    /*
     *mute- for check our music enabled or no, and change this value
     * _instanse-for get singletone object 
     * MainNusic- this variable for storage music
     */
    private bool mute;
    private static AudioSource MainMusic;
    private static MenuMusic _instanse;
    static public MenuMusic GetMainMusic()
    {
        if (_instanse==null)
           _instanse = new MenuMusic();
        return _instanse;

    }
    private MenuMusic()
    {
        mute = false;
        if (!MainMusic)
            MainMusic = GameObject.Find("MusicMainMenu").GetComponent<AudioSource>();
        
        Debug.Log("MenuMusic constructor worked");
       // initialisationMusic();
    }
    private void initialisationMusic()
    {
       
    }
    public  void play()
    {
        initialisationMusic();
        MainMusic.Play();
    }
    public  void stop()
    {
        MainMusic.Stop();
    }
    public void changeMute()
    {
        if (mute) mute = false;
        else if (!mute) mute = true;
    }
    public void setMute()
    {
        MainMusic.mute = true;
    }
    public void unsetMute()
    {
        MainMusic.mute = false;
    }
    public bool is_mute()
    {
        if (mute) return true;
        else return false;
    }
    public void changeVolume(float level)
    {
        
            
       
            MainMusic.volume = level;
    }
    public float getVolumeLevel()
    {
        return MainMusic.volume;
    }

}
