using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PressPlay : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("VariantGame");
    }
}

