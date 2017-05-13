using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player
{
    public Player()
    {
        namePlayer = " ";

    }
    public string namePlayer { set; get; }
    public string colorplayer { set; get; }
    public int moneyPlayer { set; get; }


    abstract public void makeMove();
   
	
}

public class RealPlayer: Player
{

    public RealPlayer()
    {
        namePlayer = " ";
    }
    public override void makeMove()
    {
        
    }
}
