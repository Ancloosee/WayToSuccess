using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is a singletone class,he save number of players and other setting of our game 
public class Game
{
    //for save number of player in Game
    public int numberOfPlayers { set; get; }

    private List<Player> players;
    static private Game game;

    static public Game getGame()
    {
        if (game == null)
            game = new Game();
        return game;
    }

    //default constructor
    private Game()
    {
        numberOfPlayers = 2;
    }

    //Methods for change  number of players
    //set more players
    public void changeNumberOfPlayersMore()
    {
        if(numberOfPlayers<6)
        numberOfPlayers++;
    }
    public void chamgeNumberOfPlayersLess()
    {
        
        if(numberOfPlayers>2)
        numberOfPlayers--;
    }
   


    public void setNumberOfPlayer()
    {
        numberOfPlayers = 3;
        players = new List<Player>(numberOfPlayers);
        for (int i = 0; i < numberOfPlayers; i++)
            players.Add(new RealPlayer());
        Debug.Log("Count of players: " + numberOfPlayers);
        Debug.Log("ListLengs: " + players.Count);
        

    }

    public  Player this[int index]
    {
       
        set
        {
           // Debug.Log("Imput Index" + index);
            players[index] = value;
        }
        get
        {
           // Debug.Log("Imput Index" + index);
            return players[index];
        }
    }
       

    /*Dynamic add players to the map
     parent-parent gameobj
     */
    public void addPlayersElementsToTheBoad(GameObject parent)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject tmpObj = new GameObject("Player" + (i + 1));
            tmpObj.AddComponent<RectTransform>();
            tmpObj.AddComponent<Image>();
            

            //if set first playes
            if (i == 0)
            {
                 //set min anchor
                tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(parent.GetComponent<RectTransform>().anchorMax.x + 0.2f,
                                                            parent.GetComponent<RectTransform>().anchorMin.y+0.02f);
                //set max anchor
                tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(parent.GetComponent<RectTransform>().anchorMin.x + 0.93f,
                                                     parent.GetComponent<RectTransform>().anchorMin.y - 0.04f);
                }
            else
            {
                //set odd  player
                if(i%2!=0)
                {
                    /*Change only Y coordinates*/

                    //set max anchor
                    tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(players[i - 1].position.anchorMax.x,
                                                                players[i - 1].position.anchorMax.y + 0.07f);
                    //set min anchor
                    tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(players[i - 1].position.anchorMin.x,
                                                         players[i - 1].position.anchorMax.y + 0.01f);
                 }
                //set  even player
                if(i%2==0)
                {
                    /*Change only X coordinates*/

                     //set max anchor
                    tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(players[i - 2].position.anchorMin.x - 0.005f,
                                                                players[i - 2].position.anchorMax.y);
                    //set min anchor
                    tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(players[i - 2].position.anchorMin.x - 0.05f,
                                                         players[i - 2].position.anchorMin.y);
                }

            }
            //set patern
            tmpObj.GetComponent<RectTransform>().transform.SetParent(parent.transform);

            //set scale
            tmpObj.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

            //move to anchors
            tmpObj.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            tmpObj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            tmpObj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

            Game.getGame()[i].position = tmpObj.GetComponent<RectTransform>();

            LoadPlayerPicture( tmpObj, players[i]);




        }
    }
    private void LoadPlayerPicture( GameObject obj,Player player)
    {
        string path=" ";

        if (player.colorplayer == "RedColor") path= "RedPointer";
        if (player.colorplayer == "YellowColor") path = "YellowPointer";
        if (player.colorplayer == "BlueColor") path = "BluePointer";
        if (player.colorplayer == "GreenBlueColor") path = "GreenBluePointer";
        if (player.colorplayer == "GreenColor") path = "GreenPointer";
        if (player.colorplayer == "VioletColor") path = "VioletPointer";

        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }
    
}
    
	

