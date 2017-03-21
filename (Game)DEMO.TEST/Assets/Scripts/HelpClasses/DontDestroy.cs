using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This small class created  for you need save GameObject from the previous scene*/
public class DontDestroy : MonoBehaviour
{
    public GameObject obj;
    private void Awake()
    {
        /*This method don't remove GameObject when Destroy scene*/
        DontDestroyOnLoad(obj.gameObject);
    }
}
