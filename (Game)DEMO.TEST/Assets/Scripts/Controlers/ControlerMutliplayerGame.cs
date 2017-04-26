using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlerMutliplayerGame : MonoBehaviour {

    bool chek = true;
    public int Index { set; get; }
    string name;
    string color;
    void Start()
    {

        GameObject.Find("BRight").GetComponent<Button>().onClick.AddListener(indexMore);
        GameObject.Find("BLeft").GetComponent<Button>().onClick.AddListener(indexless);
        GameObject.Find("BOK").GetComponent<Button>().onClick.AddListener(PressOk);

    }

    private void Update()
    {
        GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index + 1);
        Game.getGame()[Index].namePlayer = name;
        Game.getGame()[Index].colorplayer = color;
        Game.getGame()[Index].moneyPlayer = 20000;
    }


    private void indexMore()
    {    //if set count players
        if(chek)
        {
            Game.getGame().changeNumberOfPlayersMore();
            GameObject.Find("Number").GetComponent<Text>().text = System.Convert.ToString(Game.getGame().getNumberOfPlayers());
        }
        else
        if (Index < Game.getGame().getNumberOfPlayers()-1)
            Index++;
    }
    private void indexless()
    {
        if(chek)
        {
            Game.getGame().chamgeNumberOfPlayersLess();
            GameObject.Find("Number").GetComponent<Text>().text = System.Convert.ToString(Game.getGame().getNumberOfPlayers());
        }
        else
        if (Index > 0)
            Index--;
    }
    private void PressOk()
    {
        if(chek)
        {
            
            GameObject.Find("Number").GetComponent<Animations>().enabled = true;
            GameObject.Find("NumberPleyers").GetComponent<ChangeText>().Text = "Enter Information";
            GameObject.Find("NumberPleyers").GetComponent<ChangeText>().enabled = true;
            GameObject.Find("Part2").GetComponent<Animations>().enabled = true;
            chek = false;
            Game.getGame().setNumberOfPlayer();
        }
    }

}
