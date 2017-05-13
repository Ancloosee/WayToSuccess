using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlerMutliplayerGame : MonoBehaviour {

    bool chek = true;
    public int Index { set; get; }
    string name;
    string color;

    List<Button> ButtonList;
    void Start()
    {
        initialiseButtonList();
        Index = 1;
        GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index);
        GameObject.Find("BRight").GetComponent<Button>().onClick.AddListener(indexMore);
        GameObject.Find("BLeft").GetComponent<Button>().onClick.AddListener(indexLess);
        GameObject.Find("BOK").GetComponent<Button>().onClick.AddListener(PressOk);

        GameObject.Find("RedColor").GetComponent<Button>().onClick.AddListener(redColor);
        GameObject.Find("YellowColor").GetComponent<Button>().onClick.AddListener(yellowColor);
        GameObject.Find("BlueColor").GetComponent<Button>().onClick.AddListener(blueColor);
        GameObject.Find("GreenBlueColor").GetComponent<Button>().onClick.AddListener(greenBlueColor);
        GameObject.Find("GreenColor").GetComponent<Button>().onClick.AddListener(greenColor);
        GameObject.Find("VioletColor").GetComponent<Button>().onClick.AddListener(violetColor);

        GameObject.Find("ButtonForError").GetComponent<Button>().onClick.AddListener(PressErrorButton);

    }
    private void Update()
    {
        //Debug.Log("Update");
        //Debug.Log("Name " + name);
        //Debug.Log("Index " + Index);
        //    GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index + 1);

        //    name = GameObject.Find("NameText").GetComponent<Text>().text;
        //    Game.getGame()[Index].namePlayer = name;
        //    Game.getGame()[Index].colorplayer = color;
        //    Game.getGame()[Index].moneyPlayer = 20000;
    }
    private void initialiseButtonList()
    {
        ButtonList = new List<Button>(6);
        //initialisation list 
        ButtonList.Add(GameObject.Find("YellowColor").GetComponent<Button>());
        ButtonList.Add(GameObject.Find("BlueColor").GetComponent<Button>());
        ButtonList.Add(GameObject.Find("GreenBlueColor").GetComponent<Button>());
        ButtonList.Add(GameObject.Find("GreenColor").GetComponent<Button>());
        ButtonList.Add(GameObject.Find("RedColor").GetComponent<Button>());
        ButtonList.Add(GameObject.Find("VioletColor").GetComponent<Button>());
    }
    private void InitialiseColors(string name)
    {
        foreach (Button b in ButtonList)
        {
            if (b.name == name)
            {
                Interface.GetIterface().changeScaleOfButton(b, true);
                return;
            }
        }
    }
    
   
    
    private void redColor()
    {
        if (!chekSetColor(ButtonList[4].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }

        Interface.GetIterface().resetScaleButton(ButtonList);
        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[4]))
        {
            
            color = "RedColor";
            ColorBlock cb= ButtonList[4].colors;
            
            seachAndChangeScaleOfColorButon("RedColor",true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("RedColor", false);

        }
    }
    private void greenColor()
    {
        if (!chekSetColor(ButtonList[3].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }

        Interface.GetIterface().resetScaleButton(ButtonList);
        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[3]))
        {
            color = "GreenColor";
            seachAndChangeScaleOfColorButon("GreenColor", true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("GreenColor", false);
        }

    }
    private void greenBlueColor()
    {
        if (!chekSetColor(ButtonList[2].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }
        Interface.GetIterface().resetScaleButton(ButtonList);

        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[2]))
        {
            color = "GreenBlueColor";
            seachAndChangeScaleOfColorButon("GreenBlueColor", true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("GreenBlueColor", false);
        }


    }
    private void blueColor()
    {
        if (!chekSetColor(ButtonList[1].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }
        Interface.GetIterface().resetScaleButton(ButtonList);


        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[1]))
        {
            color = "BlueColor";
            seachAndChangeScaleOfColorButon("BlueColor", true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("BlueColor", false);
        }

    }
    private void violetColor()
    {
        if (!chekSetColor(ButtonList[5].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }
        Interface.GetIterface().resetScaleButton(ButtonList);

        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[5]))
        {
            color = "VioletColor";
            seachAndChangeScaleOfColorButon("VioletColor", true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("VioletColor", false);
        }
    }
    private void yellowColor()
    {
        if (!chekSetColor(ButtonList[0].name))
        {
            Interface.GetIterface().ShowCloseMassageBox(true, "This color was selected");
            return;
        }
        Interface.GetIterface().resetScaleButton(ButtonList);

        if (!Interface.GetIterface().chekScaleColorBatton(ButtonList[0]))
        {
            color = "YellowColor";
            seachAndChangeScaleOfColorButon("YellowColor", true);
        }
        else
        {
            color = " ";
            seachAndChangeScaleOfColorButon("YellowColor", false);
        }

    }

    private void indexMore()
    {    //if set count players
        if (chek)
        {
            Game.getGame().changeNumberOfPlayersMore();
            GameObject.Find("Number").GetComponent<Text>().text = System.Convert.ToString(Game.getGame().getNumberOfPlayers());
        }
        else
        if (Index < Game.getGame().getNumberOfPlayers())
        {
            Index++;


            setRotateButton();

            Debug.Log("Index++: " + Index);
            Interface.GetIterface().resetScaleButton(ButtonList);

            GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index);
            InitialiseColors(Game.getGame()[Index - 1].colorplayer);

            
            GameObject.Find("NameText").GetComponent<Text>().text = Game.getGame()[Index - 1].namePlayer;
            

            GameObject.Find("NameField").GetComponent<InputField>().text = Game.getGame()[Index - 1].namePlayer;
        }
    }
    private void indexLess()
    {
        if (chek)
        {
            Game.getGame().chamgeNumberOfPlayersLess();
            GameObject.Find("Number").GetComponent<Text>().text = System.Convert.ToString(Game.getGame().getNumberOfPlayers());
        }
        else
        if (Index > 1)
        {
            Index--;
            Debug.Log("Index--: " + Index);
            Interface.GetIterface().resetScaleButton(ButtonList);
            GameObject.Find("NumberPlayer").GetComponent<Text>().text = System.Convert.ToString(Index);


            setRotateButton();

            InitialiseColors(Game.getGame()[Index - 1].colorplayer);


            GameObject.Find("NameText").GetComponent<Text>().text = Game.getGame()[Index - 1].namePlayer;

            GameObject.Find("NameField").GetComponent<InputField>().text = Game.getGame()[Index - 1].namePlayer;


        }
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
            Debug.Log(Game.getGame().getNumberOfPlayers());
        }
        else
        {
            name = GameObject.Find("NameText").GetComponent<Text>().text;
            Debug.Log("Player " + (Index - 1));
            if(!chekSetName(name))
            {
                Interface.GetIterface().ShowCloseMassageBox(true, "Wrong name");
                return;
            }
            if(color==null)
            {
                Interface.GetIterface().ShowCloseMassageBox(true, "Please select color");
                return;
            }
            Game.getGame()[Index - 1].namePlayer = name;
            Debug.Log("Name " + Game.getGame()[Index - 1].namePlayer);

            Game.getGame()[Index - 1].colorplayer = color;
            Debug.Log("Color " + Game.getGame()[Index - 1].colorplayer);
           // Interface.GetIterface().rotationButton(Game.getGame()[Index - 1].colorplayer, true);
            Game.getGame()[Index - 1].moneyPlayer = 200000;
            Debug.Log("Money " + Game.getGame()[Index - 1].moneyPlayer);

            setRotateButton();

          //  EditorUtility.DisplayDialog("Hello", "Worls", "ok");
        }
    }
    private void PressErrorButton()
    {
        Interface.GetIterface().ShowCloseMassageBox(false);
    }




    /*This methods for set rotate buttons when colors set or no*/
    private void setRotateButton()
    {
        foreach (Button b in ButtonList)
        {
            if (!chekSetColor(b.name))
            {
                Interface.GetIterface().rotationButton(b.name, true);
            }
            else
                Interface.GetIterface().rotationButton(b.name, false);
        }
    }
    private bool chekSetColor(string name)
    {
        
        for(int i=0;i<Game.getGame().getNumberOfPlayers();i++)
        {
            if (Game.getGame()[i].colorplayer == name)
                return false;
        }
        return true;
    }
    private bool chekSetName(string name)
    {
        if (name == " ")
            return false;
        for (int i = 0; i < Game.getGame().getNumberOfPlayers(); i++)
        {
            if (Game.getGame()[i].namePlayer == name)
                return false;
        }
        return true;
    }
    /*
     * if flag- true ShowMassageBox
     * if flag-false closeMessageBox
    
        */
    
    private void seachAndChangeScaleOfColorButon(string colors, bool flAG)
    {
        foreach (Button b in ButtonList)
        {
            if (b.name == colors)
                Interface.GetIterface().changeScaleOfButton(b, flAG);

        }
    }
}
