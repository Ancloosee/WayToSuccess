﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameControler : MonoBehaviour
{
    private int index = 0;
    bool chek = true;
    List<BoardElements> boardElements = new List<BoardElements>();
    public void Start()
    {

       // Game.getGame().setNumberOfPlayer();
        Interface.GetIterface().addPlayersElementsToTheBoad(GameObject.Find("Board"));
        Interface.GetIterface().addInformationAboutPlayer();

        initGameobjPlayer();
        addEventForInformation();

        GameObject.Find("ThrowCubeButton").GetComponent<Button>().onClick.AddListener(Game.getGame().throwCube);
        GameObject.Find("MakeMoveButton").GetComponent<Button>().onClick.AddListener(makeMove);

        initBoardElements();
        initBoardElementsPosition();
        
        initPlayersInFirsCase();
        Interface.GetIterface().changeTextPlayer(index);
    }
    private void initBoardElements()
    {
    ///1SIDE
        //1
        boardElements.Add(new BoardElements("Start", @"BoardElements\1",boardPayOnly:new BoardPayOnly(200)));
        //2
        boardElements.Add(new BoardElements("Wreck Room", @"BoardElements\2", boardProterty: new BoardProperty(60)));
        //3
        boardElements.Add(new BoardElements("Comunity Chest", @"BoardElements\3", boardCard: new BoardCard(CARDTYPE.COMUNITY)));
        //4
        boardElements.Add(new BoardElements("Boiler Room", @"BoardElements\4", boardProterty: new BoardProperty(60)));
        //5
        boardElements.Add(new BoardElements("Formation Free", @"BoardElements\5", boardPayOnly: new BoardPayOnly(200)));
        //6
        boardElements.Add(new BoardElements("Red Van", @"BoardElements\6", boardSingleProperty: new BoardSingleProperty(200)));
        //7
        boardElements.Add(new BoardElements("Tennis Courts", @"BoardElements\7", boardProterty: new BoardProperty(100)));
        //8
        boardElements.Add(new BoardElements("Chance", @"BoardElements\8", boardCard: new BoardCard(CARDTYPE.CHANCE)));
        //9
        boardElements.Add(new BoardElements("Laundry Room", @"BoardElements\9", boardProterty: new BoardProperty(100)));
        //10
        boardElements.Add(new BoardElements("Weight Room", @"BoardElements\10", boardProterty: new BoardProperty(120)));
        //11
        boardElements.Add(new BoardElements("Rector's Office", @"BoardElements\11"));
     ///2SIDE
        //12
        boardElements.Add(new BoardElements("The Dorm", @"BoardElements\12", boardProterty: new BoardProperty(140)));
        //13
        boardElements.Add(new BoardElements("Kenrick Light And Magic", @"BoardElements\13", boardProterty: new BoardProperty(150)));
        //14
        boardElements.Add(new BoardElements("The Library", @"BoardElements\14", boardProterty: new BoardProperty(140)));
        //15
        boardElements.Add(new BoardElements("The Auditorium", @"BoardElements\15", boardProterty: new BoardProperty(160)));
        //16
        boardElements.Add(new BoardElements("Silver Van", @"BoardElements\16", boardSingleProperty: new BoardSingleProperty(200)));
        //17
        boardElements.Add(new BoardElements("The Gym", @"BoardElements\17", boardProterty: new BoardProperty(160)));
        //18
        boardElements.Add(new BoardElements("Community Chest", @"BoardElements\18", boardCard: new BoardCard(CARDTYPE.COMUNITY)));
        //19
        boardElements.Add(new BoardElements("The Heights", @"BoardElements\19", boardProterty: new BoardProperty(160)));
        //20
        boardElements.Add(new BoardElements("The Refectiry", @"BoardElements\20", boardProterty: new BoardProperty(200)));
        //21
        boardElements.Add(new BoardElements("Free Parking", @"BoardElements\21"));
     ///3SIDE
        //22
        boardElements.Add(new BoardElements("The Lobby", @"BoardElements\22", boardProterty: new BoardProperty(220)));
        //23
        boardElements.Add(new BoardElements("Chance", @"BoardElements\23", boardCard: new BoardCard(CARDTYPE.CHANCE)));
        //24
        boardElements.Add(new BoardElements("The Courtyatd", @"BoardElements\24", boardProterty: new BoardProperty(220)));
        //25
        boardElements.Add(new BoardElements("Priest DiningRoom", @"BoardElements\25", boardProterty: new BoardProperty(240)));
        //26
        boardElements.Add(new BoardElements("White Van", @"BoardElements\26", boardSingleProperty: new BoardSingleProperty(200)));
        //27
        boardElements.Add(new BoardElements("Convert Chapel", @"BoardElements\27", boardProterty: new BoardProperty(260)));
        //28
        boardElements.Add(new BoardElements("Mary Mother Of The World Chapel", @"BoardElements\28", boardProterty: new BoardProperty(260)));
        //29
        boardElements.Add(new BoardElements("Student Compyter Services", @"BoardElements\29", boardPayOnly: new BoardPayOnly(280)));
        //30
        boardElements.Add(new BoardElements("St.Charles Chapel", @"BoardElements\30", boardProterty: new BoardProperty(280)));
        //31
        boardElements.Add(new BoardElements("GoToRector's Office", @"BoardElements\31"));
        ///4SIDE
        //32
        boardElements.Add(new BoardElements("Glennon Lounge", @"BoardElements\32", boardProterty: new BoardProperty(300)));
        //33
        boardElements.Add(new BoardElements("Priest's Louge", @"BoardElements\33", boardProterty: new BoardProperty(300)));
        //34
        boardElements.Add(new BoardElements("Community Chest", @"BoardElements\34", boardCard: new BoardCard(CARDTYPE.COMUNITY)));
        //35
        boardElements.Add(new BoardElements("Kenrick Lounge", @"BoardElements\35", boardProterty: new BoardProperty(320)));
        //36
        boardElements.Add(new BoardElements("Sister's Car", @"BoardElements\36", boardSingleProperty: new BoardSingleProperty(200)));
        //37
        boardElements.Add(new BoardElements("Chance", @"BoardElements\37", boardCard: new BoardCard(CARDTYPE.CHANCE)));
        //38
        boardElements.Add(new BoardElements("St.Loseph", @"BoardElements\38", boardProterty: new BoardProperty(350)));
        //39
        boardElements.Add(new BoardElements("Room And Board", @"BoardElements\39", boardPayOnly: new BoardPayOnly(75)));
        //40
        boardElements.Add(new BoardElements("The Towel", @"BoardElements\40", boardProterty: new BoardProperty(400)));
    }
    private void initBoardElementsPosition()
    {
        int index = 0;
        //init first Board element
        

        boardElements[index].setAnchors(1, GameObject.Find("Board").GetComponent<RectTransform>().anchorMin.y + 0.13f, 
        GameObject.Find("Board").GetComponent<RectTransform>().anchorMax.x + 0.09f, 0);
        index++;

        //init 1 side little elements
        for (int i = 0; i < 9; i++)
        {
            boardElements[index].setAnchors(
                boardElements[index - 1].Positions.MinX,
                boardElements[index - 1].Positions.MaxY,
                boardElements[index-1].Positions.MinX-0.08f,
                0);
             index++;
        }


        //last element on 1 side
        
        boardElements[index].setAnchors(
            boardElements[index - 1].Positions.MinX,
            boardElements[index - 1].Positions.MaxY,
                 0,
                 0);
            index++;

        //init 2 side little elemets
        for (int i = 0; i < 9; i++)
        {
            boardElements[index].setAnchors(
                boardElements[index - 1].Positions.MaxX, 
                boardElements[index-1].Positions.MaxY+0.08f,
                boardElements[index - 1].Positions.MinX,
                boardElements[index - 1].Positions.MaxY);
                index++;
        }

        //init last element on 2 side
        
        boardElements[index].setAnchors(boardElements[index - 1].Positions.MaxX, 1,
                 boardElements[index - 1].Positions.MinX, boardElements[index - 1].Positions.MaxY);
        index++;

        //intt 3 side lettle elements
        for (int i = 0; i < 9; i++)
        {
            boardElements[index].setAnchors(
                boardElements[index-1].Positions.MaxX+0.08f, 
                1,
               boardElements[index - 1].Positions.MaxX,
               boardElements[index - 1].Positions.MaxY-0.13f);
           index++;
        }

        //init last element on 3 side
        
        boardElements[index].setAnchors(1, 1,
                boardElements[index - 1].Positions.MaxX, boardElements[index - 1].Positions.MaxY - 0.13f);
        index++;

        //init 4 side litle elements
        for (int i = 0; i < 9; i++)
        {
           
            boardElements[index].setAnchors(1, boardElements[index - 1].Positions.MinY,
                boardElements[index - 1].Positions.MinX, boardElements[index - 1].Positions.MinY - 0.08f);
            index++;
        }

        Destroy(GameObject.Find("NULL"));

    }
    private void addEventForInformation()
    {
      
        for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
        {
            Player p = Game.getGame()[i];
            GameObject.Find("InformationAboutPlayer" + (i + 1)).GetComponent<Button>().onClick.AddListener(()=> Interface.GetIterface().showPanelInformation(p));
        }
    }
    private void makeMove()
    {
        if (!Game.getGame().isGameOver())
        {

            //delete players from the current position
            boardElements[Game.getGame()[index].RealTimePosition].playersInTheCase.Remove(Game.getGame()[index].LogoPlayer);
            int local = Game.getGame()[index].makeMove(Game.getGame().Step);
            boardElements[local].playersInTheCase.Add(Game.getGame()[index].LogoPlayer);
            boardElements[local].setPositionsInTheCase();
            //BOARD PROPERTY

            if (boardElements[local].boardProterty != null)
            {
                Interface.GetIterface().createPanelForProperty(boardElements[local]);
                if (boardElements[local].boardProterty.isOwner == false)
                {
                    GameObject.Find("BoardElementBuyButton").GetComponent<Button>().onClick.AddListener(Buy);
                    GameObject.Find("BoardElementSkipButton").GetComponent<Button>().onClick.AddListener(skip);
                }
                else
                {
                    if (Game.getGame()[index].namePlayer == boardElements[local].boardProterty.OwnerName)
                    {
                        GameObject.Find("BoardElementsPayorUpdateButtonText").GetComponent<Text>().text = "Update";
                        GameObject.Find("BoardElementPayorUpdateButton").GetComponent<Button>().onClick.AddListener(Upd);
                        GameObject.Find("BoardElementSellButton").GetComponent<Button>().enabled = true;
                        GameObject.Find("BoardElementSellButton").GetComponent<Button>().onClick.AddListener(sell);
                        GameObject.Find("BoardElementSellButtonText").GetComponent<Text>().enabled = true;
                    }
                    else
                    {
                        GameObject.Find("BoardElementsPayorUpdateButtonText").GetComponent<Text>().text = "Pay rent";
                        GameObject.Find("BoardElementPayorUpdateButton").GetComponent<Button>().onClick.AddListener(payRent);

                    }
                }

            }
            //BOARD PAYONLY
            else if (boardElements[local].boardPayOnly != null)
            {
                Interface.GetIterface().createPanelForPayOnly(boardElements[local]);
                GameObject.Find("BoardElementPayButton").GetComponent<Button>().onClick.AddListener(PayOnly);

            }
            //BOARD CARD
            else if (boardElements[local].boardCard != null)
            {
                Interface.GetIterface().createPanelCard(boardElements[local]);
                chek = true;
                GameObject.Find("newDoButton").GetComponent<Button>().onClick.AddListener(doActions);

                // GameObject.Find("BoardElementDoButton").GetComponent<Button>().onClick.AddListener(delegate { Interface.GetIterface().showRandCard(boardElements[local]);});
                // doAction();

            }
            //BOARD SINGLE PROPERTY
            else if (boardElements[local].boardSingleProperty != null)
            {
                Interface.GetIterface().createPanelForSingleProperty(boardElements[local]);

                if (boardElements[local].boardSingleProperty.isOwner == false)
                {
                    GameObject.Find("BoardElementBuyButton").GetComponent<Button>().onClick.AddListener(Buy);
                    GameObject.Find("BoardElementSkipButton").GetComponent<Button>().onClick.AddListener(skip);
                }
                else
                {
                    if (Game.getGame()[index].namePlayer == boardElements[local].boardSingleProperty.OwnerName)
                    {
                        GameObject.Find("BoardElementsBuyButtonText").GetComponent<Text>().text = "Skip";
                        GameObject.Find("BoardElementBuyButton").GetComponent<Button>().onClick.AddListener(skip);
                        GameObject.Find("BoardElementSellButton").GetComponent<Button>().enabled = true;
                        GameObject.Find("BoardElementSellButton").GetComponent<Button>().onClick.AddListener(sell);
                        GameObject.Find("BoardElementSellButtonText").GetComponent<Text>().enabled = true;
                    }
                    else
                    {
                        GameObject.Find("BoardElementsBuyButtonText").GetComponent<Text>().text = "Pay rent";
                        GameObject.Find("BoardElementBuyButton").GetComponent<Button>().onClick.AddListener(payRent);

                    }
                }
            }
            else
            {
                Interface.GetIterface().showInformationAboutBoardElemets(boardElements[local]);
                skip();
            }

            Game.getGame().chekBanclotsPlayer();
        }
    }
    private void checkIndex()
    {
        if (index >= Game.getGame().numberOfPlayers) index = 0;
        return;
    }
    private void initGameobjPlayer()
    {
        for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
        {
            Game.getGame()[i].LogoPlayer = GameObject.Find("Player" + (i + 1));
        }
    }
    private void  initPlayersInFirsCase()
    {
        for (int i = 0; i <Game.getGame().numberOfPlayers ; i++)
        {
            boardElements[0].playersInTheCase.Add(Game.getGame()[i].LogoPlayer);
        }
        boardElements[0].setPositionsInTheCase();
    }
    private void Buy()
    {
        if(!Game.getGame()[index].buy(boardElements[Game.getGame()[index].RealTimePosition]))
        {
            //обработка
        }
        index++;
        checkIndex();
        Interface.GetIterface().closeInformationAboutBoardElements();
        Interface.GetIterface().changeTextPlayer(index);
        Game.getGame().chekTrow = true;

    }
    private void PayOnly()
    {
        if (!Game.getGame()[index].payOnly(boardElements[Game.getGame()[index].RealTimePosition]))
        {
            //обработка
        }
        index++;
        checkIndex();
        Interface.GetIterface().closeInformationAboutBoardElements();
        Interface.GetIterface().changeTextPlayer(index);
        Game.getGame().chekTrow = true;
    }
    private void Upd()
    {
        if (!Game.getGame()[index].updateLevel(boardElements[Game.getGame()[index ].RealTimePosition]))
        {
            //обработка
        }
        index++;
        checkIndex();
        Interface.GetIterface().closeInformationAboutBoardElements();
        Interface.GetIterface().changeTextPlayer(index);
        Game.getGame().chekTrow = true;
    }
    private void payRent()
    {
        if (!Game.getGame()[index].payRent(boardElements[Game.getGame()[index].RealTimePosition]))
        {
            //обработка
        }
        index++;
        checkIndex();
        Interface.GetIterface().closeInformationAboutBoardElements();
        Interface.GetIterface().changeTextPlayer(index);
        Game.getGame().chekTrow = true;
    }
    private void skip()
    {
        index++;
        checkIndex();
        Interface.GetIterface().closeInformationAboutBoardElements();
        Interface.GetIterface().changeTextPlayer(index);

        Game.getGame().chekTrow = true;
    }
    private void doActions()
    {
        if (chek == true)
        {
            int ID = System.Convert.ToInt32(GameObject.Find("BoardElementsIDCardText").GetComponent<Text>().text);
            int oldPos = Game.getGame()[index].RealTimePosition;
        
            Game.getGame()[index].doAction(ID, boardElements[Game.getGame()[index].RealTimePosition]);

            if (ID == 1)
            {
                boardElements[oldPos].playersInTheCase.Remove(Game.getGame()[index].LogoPlayer);
                boardElements[0].playersInTheCase.Add(Game.getGame()[index].LogoPlayer);
                Game.getGame()[index].RealTimePosition = 0;
                boardElements[0].setPositionsInTheCase();
            }
            else if (ID == 7)
            {
                boardElements[oldPos].playersInTheCase.Remove(Game.getGame()[index].LogoPlayer);
                boardElements[10].playersInTheCase.Add(Game.getGame()[index].LogoPlayer);
                //fix bug
                Game.getGame()[index].RealTimePosition = 10;
                boardElements[10].setPositionsInTheCase();
            }
            else if (ID == 6)
            {
                index--;
            }


            Interface.GetIterface().closeInformationAboutBoardElements();
            Interface.GetIterface().returnAnchors();

            GameObject.Find("newDoButton").GetComponent<Button>().enabled = false;
            GameObject.Find("newDoButtonText").GetComponent<Text>().enabled = false;
            MonoBehaviour.Destroy(GameObject.Find("BoardElementsIDCardText"));

            index++;
            checkIndex();

            Interface.GetIterface().changeTextPlayer(index);

            Game.getGame().chekTrow = true;


            chek = false;

        }
    }
    private void sell()
    {
        Game.getGame()[index].sell(boardElements[Game.getGame()[index].RealTimePosition]);
        index++;
        checkIndex();
        
        Interface.GetIterface().changeTextPlayer(index);
        Interface.GetIterface().closeInformationAboutBoardElements();
        Game.getGame().chekTrow = true;
    }
}