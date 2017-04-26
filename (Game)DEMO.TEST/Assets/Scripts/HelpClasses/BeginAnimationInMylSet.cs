using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript;
using UnityEngine.UI;

public class BeginAnimationInMylSet : MonoBehaviour {

    public void OnMouseDown()
    {
        
            GameObject.Find("Left").GetComponent<Animations>().enabled = true;
            GameObject.Find("Right").GetComponent<Animations>().enabled = true;
            GameObject.Find("Number").GetComponent<Animations>().enabled = true;
            GameObject.Find("NumberPleyers").GetComponent<ChangeText>().Text = "Enter Information";
            GameObject.Find("NumberPleyers").GetComponent<ChangeText>().enabled = true;



    }
}
