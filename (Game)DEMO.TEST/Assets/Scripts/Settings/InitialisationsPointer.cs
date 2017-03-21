using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*When scene with setting is loading,we need set position on scroll Pointer,this class special for that */
public class InitialisationsPointer : MonoBehaviour
{

	
	void Start ()
    {
        GameObject.Find("PointerMusic").transform.position= new Vector3(Interface.GetIterface().GetPositionPointerScrollMusic(), GameObject.Find("PointerMusic").transform.position.y);
        GameObject.Find("PointerSounds").transform.position = new Vector3(Interface.GetIterface().GetPositionPointerScrollSound(), GameObject.Find("PointerSounds").transform.position.y);
    }


}
