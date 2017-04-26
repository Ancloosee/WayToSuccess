using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitialisationPlayers : MonoBehaviour {

    public int Index {set; get; }
    string name;
    string color;
    void Start ()
    {
       
        GameObject.Find("BRight").GetComponent<Button>().onClick.AddListener(indexMore);
        GameObject.Find("BLeft").GetComponent<Button>().onClick.AddListener(indexless);

    }

    private void Update()
    {
        GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index + 1);
        Game.getGame()[Index].namePlayer = name;
        Game.getGame()[Index].colorplayer = color;
        Game.getGame()[Index].moneyPlayer = 20000;
    }


    private void indexMore()
    {
        if(Index<5)
        Index++;
    }
    private void indexless()
    {
        if (Index > 0)
            Index--;
    }
	
	
}
