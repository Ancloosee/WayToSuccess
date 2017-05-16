using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*This class for handle key press "Return"*/
public class Return : MonoBehaviour {

    /*If in "Setting Press Return go to main menu"*/
    public void OnMouseDown()
    {
          SceneManager.LoadScene("Main Menu");
    }
}
