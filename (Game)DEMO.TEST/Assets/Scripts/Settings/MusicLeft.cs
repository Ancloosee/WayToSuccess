using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLeft : MonoBehaviour {
    /*If one press the buton*/
    public void OnMouseDown()
    {
      
         MenuMusic.GetMainMusic().changeVolumeDown();
         Interface.GetIterface().OnMouseDownL("PointerMusic", "ScrollBarMusic");
        Interface.GetIterface().PositionScrollPointerMusicDown();
     }
    /*if preessing and holding the button*/
    public void OnMouseDrag()
    {

        MenuMusic.GetMainMusic().changeVolumeDown();
        Interface.GetIterface().OnMouseDownL("PointerMusic", "ScrollBarMusic");
        Interface.GetIterface().PositionScrollPointerMusicDown();
    }
}
