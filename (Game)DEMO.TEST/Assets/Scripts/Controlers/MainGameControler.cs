using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameControler : MonoBehaviour
{

    public void Start()
    {

        Game.getGame().setNumberOfPlayer();
        Game.getGame().addPlayersElementsToTheBoad(GameObject.Find("Board"));
        changeCameraPositions(GameObject.Find("Main Camera"), Game.getGame()[0]);
    }



    private void changeCameraPositions(GameObject camera,Player player)
    {
        float smooth = 3.0f;
        float distance = 2.0f;

        
        camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(player.position.position.x, camera.transform.position.y, player.position.position.z), Time.deltaTime * smooth);

}

}
