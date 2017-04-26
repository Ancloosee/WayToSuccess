using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlerVariantOfGame : MonoBehaviour {

	
	void Start ()
    {
        GameObject.Find("BMultyPlayer").GetComponent<Button>().onClick.AddListener(PressMultiplay);
    }


    private void PressMultiplay()
    {
        SceneManager.LoadScene("MultiplayerGameSetting");
    }
	
	
}
