using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLeft : MonoBehaviour
{
    /*If one press the buton*/
    public void OnMouseDown()
    {
        ButtonClickSound.GetSounds().changeVolumeDown();
        Interface.GetIterface().OnMouseDownL("PointerSounds", "ScrollBarSounds");
        Interface.GetIterface().PositionScrollPointerSoundDown();
    }
    /*if preessing and holding the button*/
    public void OnMouseDrag()
    {
        ButtonClickSound.GetSounds().changeVolumeDown();
        Interface.GetIterface().OnMouseDownL("PointerSounds", "ScrollBarSounds");
        Interface.GetIterface().PositionScrollPointerSoundDown();
    }
}
