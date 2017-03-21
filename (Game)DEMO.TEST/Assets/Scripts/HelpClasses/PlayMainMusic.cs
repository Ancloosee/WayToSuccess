using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMusic : MonoBehaviour
{
   /*This class for Play music when game start*/
    void Awake ()
    {
        MenuMusic.GetMainMusic().play();
     }
   
   
}
