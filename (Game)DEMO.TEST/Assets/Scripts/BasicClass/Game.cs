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
    public int Step { get; set; }


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
        {
            players.Add(new RealPlayer());
        }
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
       

    
   

    /*create and add camera to GameObj
    GameObject obj- parent gameobject
    */
    public void CreateCameraForBoard(GameObject obj)
    {
        GameObject camera = new GameObject(obj.name + "Camera");
        camera.AddComponent<RectTransform>();
        camera.AddComponent<Camera>();
        camera.GetComponent<Camera>().orthographic = false;
        camera.transform.SetParent(obj.transform);
        camera.GetComponent<Camera>().enabled = false;
    }

    /*For change Camera*/

    public void changeMainCamera(GameObject camera1,GameObject camera2)
    {
       //camera1.GetComponent<Camera>().enabled = false;

       // camera2.GetComponent<Camera>().enabled = true;
       // GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = camera2.GetComponent<Camera>();
       // camera2.transform.position = new Vector3(Game.getGame()[0].position.position.x, Game.getGame()[0].position.position.y, Game.getGame()[0].position.position.z);
       // camera2.GetComponent<Camera>().farClipPlane = 10;
       // camera2.GetComponent<Camera>().backgroundColor = camera1.GetComponent<Camera>().backgroundColor;
        
    }

    public void setFocusPlayerCamera(Player player)
    {
        //GameObject.Find("BoardCamera").GetComponent<RectTransform>().localPosition = new Vector3(player.position.localPosition.x, player.position.localPosition.y, -50);
    }


    public void throwCube()
    {
        System.Random rand = new System.Random();
        Step = rand.Next(1, 6);
        GameObject.Find("CubeNumber").GetComponent<Text>().text = System.Convert.ToString(Step);
    }

    
}
    
	

