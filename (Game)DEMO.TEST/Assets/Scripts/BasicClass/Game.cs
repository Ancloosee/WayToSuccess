using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a singletone class,he save number of players and other setting of our game 
public class Game
{
    //for save number of player in Game
    private int numberOfPlayers;

    private Player[] players;
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



    
	
}
