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
        
    }
    
   
    /*This variable for:
     * speed-for a set speed moving objects(Animation)
     * ChekPos-for a set position when object will stop(Animation)
     * PositionScrollPointerMusic-for save  pointer position  in ScrollBarMusic
     * PositionScrollPointerSounds- for save   pointer position in ScrollBarSound
    */
    private RectTransform rec;
    private const float MinPositionScrollPointer=-0.5f;
    private const float MaxPositionScrollPointer = 4f;
    private  float speed;
    private  float chekPos;
    
      /*This method for make animation when key pressed*/
      public  void KeyPress(Transform position,float TempScaleX, float TempScaleY)
    {
      
        position.transform.localScale = new Vector2(TempScaleX, TempScaleY);
    }
  
    /*This methods for animation selected other colors and names */
    
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
    //reset scale button to the standart
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
    /*Rotation Button
     *string button-name of button
     *Flag
     -true rotate
     -false reset rotate
    */
    public void rotationButton(string button,bool flag)
    {
        if (flag)
        GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 90);
        else
            GameObject.Find(button).GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    /*for show or close MessageBox
     * Flag
     true-show massage box
     false-close massage box
     * str- error text
     */
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
