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
        PlayersElements = new List<BoardElements>();
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

   public List<BoardElements> PlayersElements;

    abstract public int makeMove(int step);
    abstract public bool buy(BoardElements boardElements);
    abstract public bool payOnly(BoardElements boardElements);

    abstract public bool updateLevel(BoardElements boardElements);
    abstract public bool payRent(BoardElements boardElements);
    abstract public int doAction(int ID, BoardElements boardElements);
    abstract public void sell(BoardElements elements);
    abstract public bool chekLive();


}

public class RealPlayer : Player
{

    public RealPlayer() : base()
    {

    }

    public override int makeMove(int step)
    {
        this.RealTimePosition += step;
        //fix bugs
        if(this.RealTimePosition>40)
        {
            this.RealTimePosition -= 40;
        }
        return this.RealTimePosition;
    }
    public override bool buy(BoardElements boardElements)
    {
        //if you can buy element
        if(boardElements.boardProterty!=null)
        {
            if (boardElements.boardProterty.isOwner == false)
            {
                if (this.moneyPlayer > boardElements.boardProterty.Price)
                {
                    this.PlayersElements.Add(boardElements);
                    this.moneyPlayer -= boardElements.boardProterty.Price;
                    boardElements.boardProterty.isOwner = true;
                    boardElements.boardProterty.OwnerName = this.namePlayer;
                    return true;
                }
            }
            else
            {
                //оплата другому игроку
            }
        }
        //if you can buy element
        if (boardElements.boardSingleProperty != null)
        {
            if (boardElements.boardSingleProperty.isOwner == false)
            {
                if (this.moneyPlayer > boardElements.boardSingleProperty.Price)
                {
                    this.PlayersElements.Add(boardElements);
                    this.moneyPlayer -= boardElements.boardSingleProperty.Price;
                    boardElements.boardSingleProperty.isOwner = true;
                    boardElements.boardSingleProperty.OwnerName = this.namePlayer;
                    return true;
                }
            }
            else
            {
                //оплата другому игроку
            }
        }
        return false;
    }

    public override bool payOnly(BoardElements boardElements)
    {
        if(boardElements.boardPayOnly!=null)
        {
            if(this.moneyPlayer>boardElements.boardPayOnly.Price)
            {
                this.moneyPlayer -= boardElements.boardPayOnly.Price;
                return true;
            }
            return false;
        }
        return false;
    }

    public override bool updateLevel(BoardElements boardElements)
    {
        if(boardElements.boardProterty!=null)
        {
            if(this.moneyPlayer>boardElements.boardProterty.Price)
            {
                this.moneyPlayer -= boardElements.boardProterty.Price;
                boardElements.boardProterty.UpdateLevel++;
                return true;
            }
            
        }
        return false;
    }

    public override bool payRent(BoardElements boardElements)
    {
        if(boardElements.boardProterty!=null)
        {
            if(boardElements.boardProterty.isOwner==true)
            {
                if(this.moneyPlayer>boardElements.boardProterty.Price)
                {
                    this.moneyPlayer -= boardElements.boardProterty.Price;
                    Game.getGame().findByName(boardElements.boardProterty.OwnerName).moneyPlayer += boardElements.boardProterty.Price;
                    return true;
                }
            }
        }

        if (boardElements.boardSingleProperty != null)
        {
            if (boardElements.boardSingleProperty.isOwner == true)
            {
                if (this.moneyPlayer > boardElements.boardSingleProperty.Price)
                {
                    this.moneyPlayer -= boardElements.boardSingleProperty.Price;
                    Game.getGame().findByName(boardElements.boardSingleProperty.OwnerName).moneyPlayer += boardElements.boardSingleProperty.Price;
                    return true;
                }
            }
        }


        return false;
    }

    public override int doAction(int ID, BoardElements boardElements)
    {
        if(boardElements.boardCard.Type== CARDTYPE.CHANCE)
        {
            /*
             You need go to Start.You take 200
            */
            if(ID==1)
            {
                this.RealTimePosition = 0;
                this.moneyPlayer += 200;
                return ID;
            }
            /*
             Happy Birsday.Today is you birthday.All players give you gift 150
            */
            if (ID == 2)
            {
                for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
                {
                    Game.getGame()[i].moneyPlayer -= 150;
                    this.moneyPlayer += 150;
                }
                return ID;
            }
            /*
            Certificate 500
           */
            if (ID == 3)
            {
                this.moneyPlayer += 500;
                return ID;
            }
            /*
            Certificate 100
           */
            if (ID == 4)
            {
                this.moneyPlayer += 100;
                return ID;
            }
            /*
            Take  back one is your property
           */
            if (ID == 5)
            {
                
                return ID;
            }
            /*
            Throw dice again
           */
            if (ID == 6)
            {
                
                return ID;
            }
            /*
            Go to Rector's Office
           */
            if (ID == 7)
            {

                return ID;
            }
            /*
          Mulct 150
           */
            if (ID == 8)
            {
                this.moneyPlayer -= 150;
                return ID;
            }
            /*
       Friend birsday 200
            */
            if (ID == 9)
            {
                System.Random r = new System.Random();
                int ran = r.Next(0, Game.getGame().numberOfPlayers);
                this.moneyPlayer -= 200;
                Game.getGame()[ran].moneyPlayer += 200;
                return ID;
            }
            /*
            Bank take one is your property
          */
            if (ID == 10)
            {
                
                return ID;
            }
            /*
            Mucl 100
          */
            if (ID == 11)
            {
                this.moneyPlayer -= 100;
                return ID;
            }
        }
        if(boardElements.boardCard.Type== CARDTYPE.COMUNITY)
        {
            /*
                        You need go to Start.You take 200
                       */
            if (ID == 1)
            {
                this.RealTimePosition = 0;
                this.moneyPlayer += 200;
                return ID;
            }
            /*
             Happy Birsday.Today is you birthday.All players give you gift 150
            */
            if (ID == 2)
            {
                for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
                {
                    Game.getGame()[i].moneyPlayer -= 150;
                    this.moneyPlayer += 150;
                }
                return ID;
            }
            /*
            Certificate 500
           */
            if (ID == 3)
            {
                this.moneyPlayer += 500;
                return ID;
            }
            /*
            Certificate 100
           */
            if (ID == 4)
            {
                this.moneyPlayer += 100;
                return ID;
            }
            /*
            Take  back one is your property
           */
            if (ID == 5)
            {

                return ID;
            }
            /*
            Throw dice again
           */
            if (ID == 6)
            {

                return ID;
            }
            /*
            Go to Rector's Office
           */
            if (ID == 7)
            {

                return ID;
            }
            /*
          Mulct 150
           */
            if (ID == 8)
            {
                this.moneyPlayer -= 150;
                return ID;
            }
            /*
       Friend birsday 200
            */
            if (ID == 9)
            {
                System.Random r = new System.Random();
                int ran = r.Next(0, Game.getGame().numberOfPlayers);
                this.moneyPlayer -= 200;
                Game.getGame()[ran].moneyPlayer += 200;
                return ID;
            }
            /*
            Bank take one is your property
          */
            if (ID == 10)
            {

                return ID;
            }
            /*
            Mucl 100
          */
            if (ID == 11)
            {
                this.moneyPlayer -= 100;
                return ID;
            }
        }
        return ID;
    }

    public override bool chekLive()
    {
        if (this.moneyPlayer > 0) return true;
        return false;
    }

    public override void sell(BoardElements elements  )
    {
        if (elements.boardProterty != null)
        {
            this.moneyPlayer += elements.boardProterty.Price;
            this.PlayersElements.Remove(elements);
            elements.boardProterty.isOwner = false;
            elements.boardProterty.OwnerName = "";
            elements.boardProterty.UpdateLevel = 0;
        }
        else if(elements.boardSingleProperty!=null)
        {
            this.moneyPlayer += elements.boardSingleProperty.Price;
            this.PlayersElements.Remove(elements);
            elements.boardSingleProperty.isOwner = false;
            elements.boardSingleProperty.OwnerName = "";
           

        }
    }
}