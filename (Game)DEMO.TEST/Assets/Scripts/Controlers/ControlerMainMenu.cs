using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlerMainMenu : MonoBehaviour {

	
	void Start ()
    {
        GameObject.Find("BPlay").GetComponent<Button>().onClick.AddListener(PressPlay);
        GameObject.Find("BSetting").GetComponent<Button>().onClick.AddListener(PressSetting);
        GameObject.Find("BInstruction").GetComponent<Button>().onClick.AddListener(PressInstructions);
        GameObject.Find("BExit").GetComponent<Button>().onClick.AddListener(PressExit);
    }

	private void PressPlay()
    {
        ButtonClickSound.GetSounds().play();
        SceneManager.LoadScene("VariantGame");
    }
    private void PressSetting()
    {
        ButtonClickSound.GetSounds().play();
        SceneManager.LoadScene("Settings");
    }
    private void PressInstructions()
    {
        ButtonClickSound.GetSounds().play();
        SceneManager.LoadScene("Instruction");
    }
    private void PressExit()
    {
        ButtonClickSound.GetSounds().play();
        Application.Quit();
    }
	
 }

