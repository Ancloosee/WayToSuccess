using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class for amimations onject in the scene*/
public class Animations : MonoBehaviour
{

    public float speed;
    public float chekPos;
    private RectTransform rec;

    void Start ()
    {
        rec = GetComponent<RectTransform>();
       
	}
	void Update ()
    {
        if (rec.offsetMin.y != chekPos)
        {
            rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(rec.offsetMin.x, speed);

        }
    }
}
