using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Point
{
    float x;
    float y;
}
abstract public class Player
{
    public Player()
    {
        namePlayer = " ";
        
        RealTimePosition = 0;

    }
    //name of player
    public string namePlayer { set; get; }
    //color of other element player
    public string colorplayer { set; get; }
    //count money of player
    public int moneyPlayer { set; get; }
    //positions player
    public GameObject LogoPlayer { set; get; }

    public int RealTimePosition { set; get; }

    abstract public void makeMove();
   
  
	
}

public class RealPlayer: Player
{

    public RealPlayer() :base()
    {
        
    }
   
    public override void makeMove()
    {
        
    }
}
