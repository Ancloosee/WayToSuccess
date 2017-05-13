﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
        FirstInitPointers();
    }
    
    //public Interface()
    //{
    //    //FirstInitPointers();
    //}
    /*This variable for:
     * speed-for a set speed moving objects(Animation)
     * ChekPos-for a set position when object will stop(Animation)
     * PositionScrollPointerMusic-for save  pointer position  in ScrollBarMusic
     * PositionScrollPointerSounds- for save   pointer position in ScrollBarSound
    */
    private RectTransform rec;
    private const float MinPositionScrollPointer=-0.5f;
    private const float MaxPositionScrollPointer = 4f;
    private  float PositionScrollPointerMusic;
    private  float PositionScrollPointerSounds;
    private  float speed;
    private     float chekPos;
    

    /*
     * This two methods for a move  scrollBar in the "Setting" when you make setting
     * gameObj-this is a name pointer which moving on the scrollBar 
     * scroll-this if a name scrollBar 
    */
    public  void OnMouseDownR(string gameObj, string scroll)
    {
        // GameObject.Find(scroll).transform.position.x * 2.3f
        GameObject button = GameObject.Find(gameObj);
        if (button.transform.position.x < MaxPositionScrollPointer)
        {
            PositionScrollPointerMusicUP();
            button.transform.position = new Vector3(button.transform.position.x + 0.1f, button.transform.position.y);
        }
    }
    public  void OnMouseDownL(string gameObj, string scroll)
    {
        GameObject button = GameObject.Find(gameObj);
        if (button.transform.position.x >= MinPositionScrollPointer)
            button.transform.position = new Vector3(button.transform.position.x - 0.1f, button.transform.position.y);
    }
     /*
     * This method needs for animations pressed keys
     * When you press  button change Scale
    */
    public  void KeyPress(Transform position,float TempScaleX, float TempScaleY)
    {
      
        position.transform.localScale = new Vector2(TempScaleX, TempScaleY);
    }
    /*
     *This metods for change and save pointer coordinations in the ScrollBars
    */
    public  void PositionScrollPointerMusicUP()
    {
        if(PositionScrollPointerMusic<MaxPositionScrollPointer)
        PositionScrollPointerMusic += 0.1f;
     
    }
    public  void PositionScrollPointerMusicDown()
    {
        if(PositionScrollPointerMusic>MinPositionScrollPointer)
        PositionScrollPointerMusic -= 0.1f;
     
    }
    public  void PositionScrollPointerSoundUP()
    {
        if(PositionScrollPointerSounds<MaxPositionScrollPointer)
        PositionScrollPointerSounds += 0.1f;
    }
    public  void PositionScrollPointerSoundDown()
    {
        if(PositionScrollPointerSounds>MinPositionScrollPointer)
        PositionScrollPointerSounds -= 0.1f;
    }
    //geеters
    public  void setPositionPointerScrollMusic(float posotions)
    {
        PositionScrollPointerMusic = posotions;
    }
    public  float GetPositionPointerScrollMusic()
    {
        return PositionScrollPointerMusic;
    }
    public  float GetPositionPointerScrollSound()
    {
        return PositionScrollPointerSounds;
    }
    public  float GetBefinPosotionPointers()
    {
        return MinPositionScrollPointer;
    }
    public  void FirstInitPointers( )
    {
        PositionScrollPointerMusic = MaxPositionScrollPointer;
        PositionScrollPointerSounds =MaxPositionScrollPointer ;
     }
    
    /*This methods animation when biginning scene
     *First Init=for first initializations our parametrs 
     * Paramets:
     * Tspeed-speed move object
     * TchekPox-position when object will stop
     * obj-coordinate our object
     * AnimationBeginScene-for move object 
    */
    public void FirstInit(float Tspeed,float TchekPos,RectTransform obj)
    {
        rec = obj;
        speed = Tspeed;
        chekPos = TchekPos;
    }
    public void AnimationBeginScene()
    {
        if(rec.offsetMin.y != chekPos)
        {
            rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(rec.offsetMin.x, speed);
            
        }
    }

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

    public void rotationButton(string button,bool flag)
    {
        if (flag)
        GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 90);
        else
            GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 0);

    }
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

}
