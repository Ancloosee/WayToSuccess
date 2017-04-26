using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public string Text { get; set; }
    public void Start()
    {
        this.gameObject.GetComponent<Text>().text = Text;
    }
}
