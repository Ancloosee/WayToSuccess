using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public enum CARDTYPE { CHANCE,COMUNITY};

public struct Anchors
{
    public float MinX { set; get; }
    public float MinY { set; get; }
    public float MaxX { set; get; }
    public float MaxY { set; get; }

    public Anchors(float MaxX, float MaxY, float MinX, float MinY)
    {
        this.MaxX = MaxX;
        this.MaxY = MaxY;
        this.MinX = MinX;
        this.MinY = MinY;
    }
}

 public class BoardElements
{
    //name of player
    public string Name { get;  set; }
    //position player on the board
    public Anchors Positions { set; get; }
    //object image
    //public Image Images { set; get; }
    //count players of the element
    public int Count { set; get; }

   public List<GameObject> playersInTheCase { set; get; }


    public BoardProperty boardProterty { get; set; }
    public BoardCard boardCard { set; get; }
    public BoardPayOnly boardPayOnly { set; get; }
    public BoardSingleProperty boardSingleProperty { set; get; }
    public Sprite sprite { set; get; }
    public BoardElements(string name,string path,BoardProperty boardProterty = null,BoardCard boardCard = null,
        BoardPayOnly boardPayOnly = null,BoardSingleProperty boardSingleProperty = null)
    {
        Name = name;

        this.boardCard = boardCard;
        this.boardPayOnly = boardPayOnly;
        this.boardProterty = boardProterty;
        this.boardSingleProperty = boardSingleProperty;
        this.sprite = new Sprite();
        
        this.sprite= Resources.Load<Sprite>(path);
        playersInTheCase = new List<GameObject>();
    

        Count = 0;
      
    }

    public void setAnchors(float MaxX,float MaxY,float MinX,float MinY)
    {
        Positions = new Anchors(MaxX, MaxY, MinX, MinY);
    }
    public void setPositionsInTheCase(List<GameObject> playersLogo=null)
    {
        Count = playersInTheCase.Count;
        //if odd count of players 
        if(Count%2!=0)Count++;
        if(Count>2)
        Count /= 2;

        float length = (Positions.MaxX - Positions.MinX) / Count;
        float width = (Positions.MaxY - Positions.MinY) / Count;

        for (int i = 0; i < this.playersInTheCase.Count; i++)
        {
            //first element
            if(i==0)
            {
                playersInTheCase[i].GetComponent<RectTransform>().anchorMax = new Vector2(Positions.MaxX,Positions.MinY + width);
                playersInTheCase[i].GetComponent<RectTransform>().anchorMin = new Vector2(Positions.MaxX - length, Positions.MinY);


                playersInTheCase[i].GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                playersInTheCase[i].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                playersInTheCase[i].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            }
            //even element
            else if(i%2==0)
            {
                playersInTheCase[i].GetComponent<RectTransform>().anchorMax = new Vector2(playersInTheCase[i - 2].GetComponent<RectTransform>().anchorMin.x-0.005f, playersInTheCase[i - 2].GetComponent<RectTransform>().anchorMax.y);
                playersInTheCase[i].GetComponent<RectTransform>().anchorMin = new Vector2(playersInTheCase[i - 2].GetComponent<RectTransform>().anchorMin.x-length, playersInTheCase[i - 2].GetComponent<RectTransform>().anchorMin.y);

                playersInTheCase[i].GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                playersInTheCase[i].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                playersInTheCase[i].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            }
            //odd element
            else if(i%2!=0)
            {
                playersInTheCase[i].GetComponent<RectTransform>().anchorMax = new Vector2(playersInTheCase[i-1].GetComponent<RectTransform>().anchorMax.x, playersInTheCase[i - 1].GetComponent<RectTransform>().anchorMax.y+width);
                playersInTheCase[i].GetComponent<RectTransform>().anchorMin = new Vector2(playersInTheCase[i - 1].GetComponent<RectTransform>().anchorMin.x, playersInTheCase[i - 1].GetComponent<RectTransform>().anchorMax.y);
                playersInTheCase[i].GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                playersInTheCase[i].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                playersInTheCase[i].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            }


        }
    }




}

public class BoardProperty
{


    public int UpdateLevel { set; get; }

    public string OwnerName { set; get; }

    public bool isOwner { set; get; }

    public int Price { set; get; }

    public BoardProperty(int price)
    {
        Price = price;
        OwnerName = " ";
        isOwner = false;
        UpdateLevel = 0;
    }
}

public class BoardCard
{
    //Chanse or CommunityChest
    public CARDTYPE Type { set; get; }
    //for save Image and ID card
 
    public Dictionary<int,Image> Images { set; get; }
    private Image tmpImage= GameObject.Find("NULL").GetComponent<Image>();


    public BoardCard(CARDTYPE type)
    {
        Type = type;
        this.Images = new Dictionary<int, Image>();


        if (Type== CARDTYPE.CHANCE)
        {
            string path = @"CHANSE\";
            Sprite[] tmpList = Resources.LoadAll<Sprite>(path);
            for (int i = 0; i < tmpList.Length; i++)
            {
                tmpImage.sprite = tmpList[i];
                Images.Add(i + 1, tmpImage);
            }
        }
        if(Type== CARDTYPE.COMUNITY)
        {
            string path = @"Community\";
            Sprite[] tmpList = Resources.LoadAll<Sprite>(path);
            
            for (int i = 0; i < tmpList.Length; i++)
            {
                tmpImage.sprite = tmpList[i];
                Images.Add(i + 1, tmpImage);
            }
        }
    }
}

public class BoardPayOnly
{
    public int Price { set; get; }

    public BoardPayOnly(int price)
    {
        Price = price;
    }
}

public class BoardSingleProperty
{
    public int Price { set; get; }

    public string OwnerName { set; get; }

    public bool isOwner { set; get; }
    public BoardSingleProperty(int price)
    {
        OwnerName = " ";
        isOwner = false;
        Price = price;
    }
}


