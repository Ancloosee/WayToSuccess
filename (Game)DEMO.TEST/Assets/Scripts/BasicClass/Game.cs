using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a singletone class,he save number of players and other setting of our game 
public class Game
{
    //for save number of player in Game
    private int numberOfPlayers;

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
    public int getNumberOfPlayers()
    {
        return numberOfPlayers;
    }

    public void setNumberOfPlayer()
    {
        
            players = new List<Player>(numberOfPlayers);
        for(int i=0;i<numberOfPlayers;i++)
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
       



    
	
}
