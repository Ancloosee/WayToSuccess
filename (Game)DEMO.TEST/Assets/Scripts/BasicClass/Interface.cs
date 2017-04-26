using System.Collections;
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

    

    

}
