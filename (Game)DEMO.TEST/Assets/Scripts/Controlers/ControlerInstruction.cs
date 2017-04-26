using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlerInstruction : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject.Find("BReturn").GetComponent<Button>().onClick.AddListener(PressReturn);
    }


    private void PressReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }


	
	
}
