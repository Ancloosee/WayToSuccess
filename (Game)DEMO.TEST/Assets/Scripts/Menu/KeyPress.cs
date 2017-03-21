using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
   
    public float StartScale = 1.1F;
    public float TempScale = 1.2F;
    
    private void OnMouseDown()
    {
        Interface.GetIterface().KeyPress(transform,TempScale, TempScale);
        Debug.Log("ButtonClick");

        ButtonClickSound.GetSounds().play();
        
    }
    private void OnMouseUp()
    {
        Interface.GetIterface().KeyPress(transform, StartScale, StartScale);
    }
    
 
}
