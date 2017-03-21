using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRigth : MonoBehaviour
{
    /*If one press the buton*/
    public void OnMouseDown()
    {
        ButtonClickSound.GetSounds().changeVolumeUp();
        Interface.GetIterface().OnMouseDownR("PointerSounds", "ScrollBarSounds");
        Interface.GetIterface().PositionScrollPointerSoundUP();
    }
    /*if preessing and holding the button*/
    public void OnMouseDrag()
    {
        ButtonClickSound.GetSounds().changeVolumeUp();
        Interface.GetIterface().OnMouseDownR("PointerSounds", "ScrollBarSounds");
        Interface.GetIterface().PositionScrollPointerSoundUP();
    }
}
