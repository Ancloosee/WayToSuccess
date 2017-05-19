using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Interface 
{
    private static Interface _interface;
    public static Interface GetIterface()
    {
        if (_interface == null)
             _interface = new Interface();
        return _interface;
    }
    public Interface()
    {
        
    }
    
   
    /*This variable for:
     * speed-for a set speed moving objects(Animation)
     * ChekPos-for a set position when object will stop(Animation)
     * PositionScrollPointerMusic-for save  pointer position  in ScrollBarMusic
     * PositionScrollPointerSounds- for save   pointer position in ScrollBarSound
    */
    private RectTransform rec;
    private const float MinPositionScrollPointer=-0.5f;
    private const float MaxPositionScrollPointer = 4f;
    private  float speed;
    private  float chekPos;
    
      /*This method for make animation when key pressed*/
      public  void KeyPress(Transform position,float TempScaleX, float TempScaleY)
    {
      
        position.transform.localScale = new Vector2(TempScaleX, TempScaleY);
    }
  
    /*This methods for animation selected other colors and names */
    
    public void changeScaleOfButton(UnityEngine.UI.Button button,bool flag)
    {
        if(flag)
        button.transform.localScale = new Vector2(button.transform.localScale.x + 0.5f, button.transform.localScale.y + 0.5f);
        else
            button.transform.localScale = new Vector2(button.transform.localScale.x - 0.5f, button.transform.localScale.y - 0.5f);
    }
    //for chek scale of button
    //return true if scale is increased
    //if scale is no increased return false
    public bool chekScaleColorBatton(UnityEngine.UI.Button button)
    {
        if (button.transform.localScale.x > 1 && button.transform.localScale.y > 1)
            return true;
        return false;
    }
    //reset scale button to the standart
    public void resetScaleButton(List<UnityEngine.UI.Button> list)
    {
        foreach(UnityEngine.UI.Button button in list)
        {
            if(chekScaleColorBatton(button))
            {
                changeScaleOfButton(button, false);
            }
        }
    }
    /*Rotation Button
     *string button-name of button
     *Flag
     -true rotate
     -false reset rotate
    */
    public void rotationButton(string button,bool flag)
    {
        if (flag)
        GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 90);
        else
            GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    /*for show or close MessageBox
     * Flag
     true-show massage box
     false-close massage box
     * str- error text
     */
    public void ShowCloseMassageBox(bool flag, string str = " ")
    {
        if (flag)
        {
            GameObject.Find("ErrorPanel").GetComponent<UnityEngine.UI.Image>().enabled = true;
            GameObject.Find("ButtonForError").GetComponent<UnityEngine.UI.Image>().enabled = true;
            GameObject.Find("ButtonForError").GetComponent<UnityEngine.UI.Button>().enabled = true;
            GameObject.Find("TextButtonForError").GetComponent<UnityEngine.UI.Text>().enabled = true;
            GameObject.Find("ErrorText").GetComponent<UnityEngine.UI.Text>().enabled = true;
            GameObject.Find("ErrorText").GetComponent<UnityEngine.UI.Text>().text = str;
        }
        else
        {
            GameObject.Find("ErrorPanel").GetComponent<UnityEngine.UI.Image>().enabled = false;
            GameObject.Find("ButtonForError").GetComponent<UnityEngine.UI.Image>().enabled = false;
            GameObject.Find("ButtonForError").GetComponent<UnityEngine.UI.Button>().enabled = false;
            GameObject.Find("TextButtonForError").GetComponent<UnityEngine.UI.Text>().enabled = false;
            GameObject.Find("ErrorText").GetComponent<UnityEngine.UI.Text>().enabled = false;

        }

    }

    /*Dynamic add players to the map
     parent-parent gameobj
     */
    public void addPlayersElementsToTheBoad(GameObject parent)
    {
        for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
        {
            GameObject tmpObj = new GameObject("Player" + (i + 1));
            tmpObj.AddComponent<RectTransform>();
            tmpObj.AddComponent<Image>();




            //if set first playes
            if (i == 0)
            {
                //set min anchor
                tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(parent.GetComponent<RectTransform>().anchorMax.x + 0.2f,
                                                            parent.GetComponent<RectTransform>().anchorMin.y + 0.02f);
                //set max anchor
                tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(parent.GetComponent<RectTransform>().anchorMin.x + 0.93f,
                                                     parent.GetComponent<RectTransform>().anchorMin.y - 0.04f);
            }
            else
            {
                //set odd  player
                if (i % 2 != 0)
                {
                    /*Change only Y coordinates*/

                    //set max anchor
                    tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(Game.getGame()[i - 1].position.anchorMax.x,
                                                                Game.getGame()[i - 1].position.anchorMax.y + 0.07f);
                    //set min anchor
                    tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(Game.getGame()[i - 1].position.anchorMin.x,
                                                         Game.getGame()[i - 1].position.anchorMax.y + 0.01f);
                }
                //set  even player
                if (i % 2 == 0)
                {
                    /*Change only X coordinates*/

                    //set max anchor
                    tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(Game.getGame()[i - 2].position.anchorMin.x - 0.005f,
                                                                Game.getGame()[i - 2].position.anchorMax.y);
                    //set min anchor
                    tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(Game.getGame()[i - 2].position.anchorMin.x - 0.05f,
                                                         Game.getGame()[i - 2].position.anchorMin.y);
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

            LoadPlayerPicture(tmpObj, Game.getGame()[i]);




        }
    }
    private void LoadPlayerPicture(GameObject obj, Player player)
    {
        string path = " ";

        if (player.colorplayer == "RedColor") path = "RedPointer";
        if (player.colorplayer == "YellowColor") path = "YellowPointer";
        if (player.colorplayer == "BlueColor") path = "BluePointer";
        if (player.colorplayer == "GreenBlueColor") path = "GreenBluePointer";
        if (player.colorplayer == "GreenColor") path = "GreenPointer";
        if (player.colorplayer == "VioletColor") path = "VioletPointer";

        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }

    public void addInformationAboutPlayer()
    {
        for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
        {
            GameObject tmpobj = new GameObject("InformationAboutPlayer" + (i + 1));

            tmpobj.transform.SetParent(GameObject.Find("Canvas").transform);

            tmpobj.AddComponent<RectTransform>();
            tmpobj.AddComponent<Button>();

            if (i == 0)
            {
                //set min anchor
                tmpobj.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("ThrowCubeButton").GetComponent<RectTransform>().anchorMax.x,
                                                            GameObject.Find("ThrowCubeButton").GetComponent<RectTransform>().anchorMin.y - 0.02f);
                //set max anchor
                tmpobj.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("ThrowCubeButton").GetComponent<RectTransform>().anchorMin.x,
                                                     GameObject.Find("ThrowCubeButton").GetComponent<RectTransform>().anchorMax.y - 0.2f);
            }
            else
            {
                //set min anchor
                tmpobj.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("InformationAboutPlayer"+(i)).GetComponent<RectTransform>().anchorMax.x,
                                                            GameObject.Find("InformationAboutPlayer" + (i)).GetComponent<RectTransform>().anchorMin.y + 0.02f);
                //set max anchor
                tmpobj.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("InformationAboutPlayer" + (i)).GetComponent<RectTransform>().anchorMin.x,
                                                     GameObject.Find("InformationAboutPlayer" + (i)).GetComponent<RectTransform>().anchorMax.y - 0.2f);
            }
            tmpobj.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            tmpobj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            tmpobj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            tmpobj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            
            GameObject tmpText = new GameObject("InformationTextPlayer" + (i + 1));
            tmpText.transform.SetParent(tmpobj.transform);
            tmpText.AddComponent<RectTransform>();

            tmpText.transform.SetParent(tmpobj.transform);
            tmpText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            tmpText.GetComponent<RectTransform>().anchorMin= new Vector2(0,0);
            tmpText.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            tmpText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            tmpText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);



            tmpText.AddComponent<Text>();
            tmpText.GetComponent<Text>().text = Game.getGame()[i].namePlayer + "\n" + "Money: " + Game.getGame()[i].moneyPlayer;
            tmpText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            tmpText.GetComponent<Text>().font= GameObject.Find("CubeNumber").GetComponent<Text>().font;


            tmpText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }
    }


    

}
