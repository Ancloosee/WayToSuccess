using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRigth : MonoBehaviour
{
    /*If one press the buton*/
    public void OnMouseDown()
    {
        MenuMusic.GetMainMusic().changeVolumeUp();
        Interface.GetIterface().OnMouseDownR("PointerMusic", "ScrollBarMusic");
        Interface.GetIterface().PositionScrollPointerMusicUP();
    }
    /*if preessing and holding the button*/
    public void OnMouseDrag()
    {
        MenuMusic.GetMainMusic().changeVolumeUp();
        Interface.GetIterface().OnMouseDownR("PointerMusic", "ScrollBarMusic");
        Interface.GetIterface().PositionScrollPointerMusicUP();
    }
}
