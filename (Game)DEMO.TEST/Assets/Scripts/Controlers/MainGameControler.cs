using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameControler : MonoBehaviour
{

    public void Start()
    {

        //Game.getGame().setNumberOfPlayer();
        Interface.GetIterface().addPlayersElementsToTheBoad(GameObject.Find("Board"));
        Interface.GetIterface().addInformationAboutPlayer();
        addEventForInformation();
        // Game.getGame().CreateCameraForBoard(GameObject.Find("Board"));
        //  Game.getGame().changeMainCamera(GameObject.Find("Main Camera"), GameObject.Find("BoardCamera"));
        // GameObject.Find("ButtonTemp").GetComponent<Button>().onClick.AddListener(tmp);

        //Game.getGame().setFocusPlayerCamera(Game.getGame()[0]);




        //}
        //private void tmp()
        //{
        //    changeCameraPositions(GameObject.Find("BoardCamera"), Game.getGame()[5]);
        //}



        //private void changeCameraPositions(GameObject camera,Player player)
        //{
        //    float smooth = 3.0f;
        //    float distance = 2.0f;


        //    camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(player.position.position.x, player.position.position.y, -50), Time.deltaTime * smooth);

        //    }   

    }

    private void addEventForInformation()
    {
        for (int i = 0; i < Game.getGame().numberOfPlayers; i++)
        {
            GameObject.Find("InformationAboutPlayer" + (i + 1)).GetComponent<Button>().onClick.AddListener(delegate { showPanelInformation(Game.getGame()[i]); });
        }
    }

    private void showPanelInformation(Player player)
    {
        GameObject.Find("PanelNamePlayer").GetComponent<Text>().text = player.namePlayer;
        GameObject.Find("PanelPealPlayerMoney").GetComponent<Text>().text = player.moneyPlayer+" $";

        GameObject.Find("InformationPanelAboutPlayer").GetComponent<Animation>().enabled = true;

    }
}
