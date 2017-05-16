using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeNumberOfPlayersLess : MonoBehaviour {

    void OnMouseDown()
    {

        Game.getGame().chamgeNumberOfPlayersLess();
        GameObject.Find("Number").GetComponent<Text>().text = System.Convert.ToString(Game.getGame().numberOfPlayers);
    }



}
