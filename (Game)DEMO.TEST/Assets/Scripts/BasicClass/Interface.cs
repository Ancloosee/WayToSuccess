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
    private const float MinPositionScrollPointer = -0.5f;
    private const float MaxPositionScrollPointer = 4f;
    private float speed;
    private float chekPos;

    public List<GameObject> PlayersLogo = new List<GameObject>();
    /*This method for make animation when key pressed*/
    public void KeyPress(Transform position, float TempScaleX, float TempScaleY)
    {

        position.transform.localScale = new Vector2(TempScaleX, TempScaleY);
    }

    /*This methods for animation selected other colors and names */

    public void changeScaleOfButton(UnityEngine.UI.Button button, bool flag)
    {
        if (flag)
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
        foreach (UnityEngine.UI.Button button in list)
        {
            if (chekScaleColorBatton(button))
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
    public void rotationButton(string button, bool flag)
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

            tmpObj.GetComponent<Image>().type = Image.Type.Simple;
            tmpObj.GetComponent<Image>().preserveAspect = true;

            ////if set first playes
            //if (i == 0)
            //{
            //    //set min anchor
            //    tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(parent.GetComponent<RectTransform>().anchorMax.x + 0.2f,
            //                                                parent.GetComponent<RectTransform>().anchorMin.y + 0.02f);
            //    //set max anchor
            //    tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(parent.GetComponent<RectTransform>().anchorMin.x + 0.93f,
            //                                         parent.GetComponent<RectTransform>().anchorMin.y - 0.04f);
            //}
            //else
            //{
            //    //set odd  player
            //    if (i % 2 != 0)
            //    {
            //        /*Change only Y coordinates*/

            //        //set max anchor
            //        tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(Game.getGame()[i - 1].position.anchorMax.x,
            //                                                    Game.getGame()[i - 1].position.anchorMax.y + 0.07f);
            //        //set min anchor
            //        tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(Game.getGame()[i - 1].position.anchorMin.x,
            //                                             Game.getGame()[i - 1].position.anchorMax.y + 0.01f);
            //    }
            //    //set  even player
            //    if (i % 2 == 0)
            //    {
            //        /*Change only X coordinates*/

            //        //set max anchor
            //        tmpObj.GetComponent<RectTransform>().anchorMax = new Vector2(Game.getGame()[i - 2].position.anchorMin.x - 0.005f,
            //                                                    Game.getGame()[i - 2].position.anchorMax.y);
            //        //set min anchor
            //        tmpObj.GetComponent<RectTransform>().anchorMin = new Vector2(Game.getGame()[i - 2].position.anchorMin.x - 0.05f,
            //                                             Game.getGame()[i - 2].position.anchorMin.y);
            //    }

            //}
            //set patern
            tmpObj.GetComponent<RectTransform>().transform.SetParent(parent.transform);

            //set scale
            tmpObj.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);

            //move to anchors
            tmpObj.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            tmpObj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            tmpObj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

           // Game.getGame()[i].position = tmpObj.GetComponent<RectTransform>();

            LoadPlayerPicture(tmpObj, Game.getGame()[i]);


            //PlayersLogo.Add(tmpObj);

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
                tmpobj.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("InformationAboutPlayer" + (i)).GetComponent<RectTransform>().anchorMax.x,
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
            tmpText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            tmpText.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            tmpText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            tmpText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);



            tmpText.AddComponent<Text>();
            tmpText.GetComponent<Text>().text = Game.getGame()[i].namePlayer + "\n" + "Money: " + Game.getGame()[i].moneyPlayer;
            tmpText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            tmpText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;


            tmpText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }
    }

    public void showPanelInformation(Player player)
    {
        GameObject.Find("PanelNamePlayer").GetComponent<Text>().text = player.namePlayer;
        GameObject.Find("PanelPealPlayerMoney").GetComponent<Text>().text = player.moneyPlayer + " $";
        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animations>().speed = 5;
        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animations>().chekPos = 0;
        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animations>().enabled = true;
        GameObject.Find("CloseButton").GetComponent<Button>().onClick.AddListener(closePanelInformation);
    }
    private void closePanelInformation()
    {
        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animations>().speed = -5;
        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animations>().chekPos = -500;
    }

    public void showInformationAboutBoardElemets(BoardElements elements)
    {

        GameObject.Find("BoardElementInformation").GetComponent<Animations>().speed = 5;
        GameObject.Find("BoardElementInformation").GetComponent<Animations>().chekPos = 0;

        GameObject.Find("NameBoardElements").GetComponent<Text>().text = elements.Name;
        GameObject.Find("LogoBoardElements").GetComponent<Image>().sprite = elements.sprite;


        GameObject.Find("BoardElementsCloseButton").GetComponent<Button>().onClick.AddListener(closeInformationAboutBoardElements);
    }
    public void closeInformationAboutBoardElements()
    {
        GameObject.Find("BoardElementInformation").GetComponent<Animations>().speed = -5;
        GameObject.Find("BoardElementInformation").GetComponent<Animations>().chekPos = -715;

        try
        {
            destroyPropertyPanel();
        }
        catch(System.Exception ex)
        {

        }
        try
        {
            destroyPayOnlyPanel();
        }
        catch (System.Exception ex)
        {

        }
        try
        {
            destroySinglePropertyPanel();
        }
        catch (System.Exception ex)
        {

        }

        try
        {
           destroyCardPanel()
;
        }
        catch (System.Exception ex)
        {

        }

    }

    //create and destroy PropertyPanel
    public void createPanelForProperty(BoardElements element)
    {
        showInformationAboutBoardElemets(element);
        /*-----------------CREATE TEXT--------------------------------*/
        //add text for show price propetry
        GameObject textPrice = new GameObject("BoardElementsPrice");
        textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        textPrice.AddComponent<RectTransform>();
        textPrice.AddComponent<Text>();
        //set anchors position
        textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y);
        textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y - 0.15f);
        textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
        textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text settings
        textPrice.GetComponent<Text>().resizeTextForBestFit = true;
        textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textPrice.GetComponent<Text>().font= GameObject.Find("CubeNumber").GetComponent<Text>().font;
        textPrice.GetComponent<Text>().text ="Price: "+System.Convert.ToString(element.boardProterty.Price);
        /*NEW OBJECT*/
        //text for ownerName
        textPrice = new GameObject("BoardElementUpdateLevel");
        textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        textPrice.AddComponent<RectTransform>();
        textPrice.AddComponent<Text>();
        //set anchors position
        textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementsPrice").GetComponent<RectTransform>().anchorMin.y-0.1f);
        textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementsPrice").GetComponent<RectTransform>().anchorMin.y - 0.25f);
        textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
        textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text settings
        textPrice.GetComponent<Text>().resizeTextForBestFit = true;
        textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textPrice.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        textPrice.GetComponent<Text>().text = "Update Level: " + System.Convert.ToString(element.boardProterty.UpdateLevel);
        //if element have owner
        if (element.boardProterty.isOwner == true)
        {
            //new object text for ownerName
            textPrice = new GameObject("BoardElementOwnerName");
            textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
            textPrice.AddComponent<RectTransform>();
            textPrice.AddComponent<Text>();
            textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementUpdateLevel").GetComponent<RectTransform>().anchorMin.y-0.1f);
            textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementUpdateLevel").GetComponent<RectTransform>().anchorMin.y - 0.25f);
            textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
            textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //set text settings
            textPrice.GetComponent<Text>().resizeTextForBestFit = true;
            textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            textPrice.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
            textPrice.GetComponent<Text>().text = "Owner: " + element.boardProterty.OwnerName;
        }


        /*---------------CREATE BUTTONS------------------*/

        GameObject button = new GameObject("BoardElementBuyButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        
        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y-0.15f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.3f);
        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
        GameObject buttonText = new GameObject("BoardElementsBuyButtonText");
        buttonText.transform.SetParent(GameObject.Find("BoardElementBuyButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "Buy";


        /*NEW BUTTON*/
        //SkipButton
       button = new GameObject("BoardElementSkipButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("BoardElementBuyButton").GetComponent<RectTransform>().anchorMin.y-0.15f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("BoardElementBuyButton").GetComponent<RectTransform>().anchorMin.y - 0.3f);

        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
         buttonText = new GameObject("BoardElementSkipButton");
        buttonText.transform.SetParent(GameObject.Find("BoardElementSkipButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "Skip";



        
    }
    private void destroyPropertyPanel()
    {
        
        MonoBehaviour.Destroy(GameObject.Find("BoardElementsPrice"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementUpdateLevel"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementBuyButton"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementSkipButton"));
        try
        {
            MonoBehaviour.Destroy(GameObject.Find("BoardElementOwnerName"));
        }
        catch (System.Exception ex)
        {

        }
    }

    //create and destroy PayOnlypanel
    public void createPanelForPayOnly(BoardElements element)
    {
        showInformationAboutBoardElemets(element);
        /*-----------------CREATE TEXT--------------------------------*/
        //add text for show price propetry
        GameObject textPrice = new GameObject("BoardElementsPrice");
        textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        textPrice.AddComponent<RectTransform>();
        textPrice.AddComponent<Text>();
        //set anchors position
        textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y);
        textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y - 0.15f);
        textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
        textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text settings
        textPrice.GetComponent<Text>().resizeTextForBestFit = true;
        textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textPrice.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        textPrice.GetComponent<Text>().text = "You need pay: " + System.Convert.ToString(element.boardPayOnly.Price);



        /*---------------CREATE BUTTONS------------------*/

        GameObject button = new GameObject("BoardElementPayButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.15f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.3f);
        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
        GameObject buttonText = new GameObject("BoardElementsPayButtonText");
        buttonText.transform.SetParent(GameObject.Find("BoardElementPayButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "Pay";


    }
    public void  destroyPayOnlyPanel()
    {
        MonoBehaviour.Destroy(GameObject.Find("BoardElementsPrice"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementPayButton"));
    }

    //create and destroy SingleProperty Panel
    public void createPanelForSingleProperty(BoardElements element)
    {
        showInformationAboutBoardElemets(element);
        /*-----------------CREATE TEXT--------------------------------*/
        //add text for show price propetry
        GameObject textPrice = new GameObject("BoardElementsPrice");
        textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        textPrice.AddComponent<RectTransform>();
        textPrice.AddComponent<Text>();
        //set anchors position
        textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y);
        textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementsCloseButton").GetComponent<RectTransform>().anchorMin.y - 0.15f);
        textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
        textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text settings
        textPrice.GetComponent<Text>().resizeTextForBestFit = true;
        textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textPrice.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        textPrice.GetComponent<Text>().text = "Price: " + System.Convert.ToString(element.boardSingleProperty.Price);
        /*NEW OBJECT*/
        //if element have owner
        if (element.boardSingleProperty.isOwner == true)
        {
            //new object text for ownerName
            textPrice = new GameObject("BoardElementOwnerName");
            textPrice.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
            textPrice.AddComponent<RectTransform>();
            textPrice.AddComponent<Text>();
            textPrice.GetComponent<RectTransform>().anchorMax = new Vector2(1, GameObject.Find("BoardElementsPrice").GetComponent<RectTransform>().anchorMin.y);
            textPrice.GetComponent<RectTransform>().anchorMin = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMax.x, GameObject.Find("BoardElementsPrice").GetComponent<RectTransform>().anchorMin.y - 0.15f);
            textPrice.GetComponent<RectTransform>().localPosition = Vector3.zero;
            textPrice.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            textPrice.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            textPrice.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            //set text settings
            textPrice.GetComponent<Text>().resizeTextForBestFit = true;
            textPrice.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            textPrice.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
            textPrice.GetComponent<Text>().text = "Owner: " + element.boardSingleProperty.OwnerName;
        }


        /*---------------CREATE BUTTONS------------------*/

        GameObject button = new GameObject("BoardElementBuyButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.15f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.3f);
        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
        GameObject buttonText = new GameObject("BoardElementsBuyButtonText");
        buttonText.transform.SetParent(GameObject.Find("BoardElementBuyButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "Buy";


        /*NEW BUTTON*/
        //SkipButton
        button = new GameObject("BoardElementSkipButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("BoardElementBuyButton").GetComponent<RectTransform>().anchorMin.y-0.15f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("BoardElementBuyButton").GetComponent<RectTransform>().anchorMin.y - 0.3f);

        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
        buttonText = new GameObject("BoardElementSkipButton");
        buttonText.transform.SetParent(GameObject.Find("BoardElementSkipButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "Skip";

    }
    private void destroySinglePropertyPanel()
    {
        MonoBehaviour.Destroy(GameObject.Find("BoardElementsPrice"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementBuyButton"));
        MonoBehaviour.Destroy(GameObject.Find("BoardElementSkipButton"));
        try
        {
            MonoBehaviour.Destroy(GameObject.Find("BoardElementOwnerName"));
        }
        catch (System.Exception ex)
        {

        }
    }

    //create and destroy cardPanel

    public void createPanelCard(BoardElements element)
    {
        showInformationAboutBoardElemets(element);
        /*---------------CREATE BUTTONS------------------*/
        GameObject button = new GameObject("BoardElementDoButton");
        button.transform.SetParent(GameObject.Find("BoardElementInformation").transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        //set anchors 
        button.GetComponent<RectTransform>().anchorMax = new Vector2(GameObject.Find("LogoBoardElements").GetComponent<RectTransform>().anchorMin.x, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.2f);
        button.GetComponent<RectTransform>().anchorMin = new Vector2(0, GameObject.Find("NameBoardElements").GetComponent<RectTransform>().anchorMin.y - 0.35f);
        button.GetComponent<RectTransform>().localPosition = Vector3.zero;
        button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        button.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        button.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

        //create text for button
        GameObject buttonText = new GameObject("BoardElementsBuyButtonText");
        buttonText.transform.SetParent(GameObject.Find("BoardElementDoButton").transform);
        buttonText.AddComponent<RectTransform>();
        buttonText.AddComponent<Text>();
        //set achors
        buttonText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        buttonText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buttonText.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        buttonText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //set text

        buttonText.GetComponent<Text>().font = GameObject.Find("CubeNumber").GetComponent<Text>().font;
        buttonText.GetComponent<Text>().resizeTextForBestFit = true;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        buttonText.GetComponent<Text>().text = "DO ";

    }

    private void destroyCardPanel()
    {
        MonoBehaviour.Destroy(GameObject.Find("BoardElementDoButton"));
    }




    public void animationTrowCube()
    {
        



    }

    
}





