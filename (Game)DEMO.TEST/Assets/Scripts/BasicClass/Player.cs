using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player
{
    private string namePlayer;
    private string colorplayer;
    private int moneyPlayer;

    public void setNamePlayer(string name)
    {
        this.namePlayer = name;
    }
    public void setColorPlayer(string color)
    {
        this.colorplayer = color;
    }
    public void setMoneyPlayer(int money)
    {
        this.moneyPlayer = money;
    }
    abstract public void makeMove();
   
	
}

public class RealPlayer: Player
{

    public override void makeMove()
    {
        
    }
}
