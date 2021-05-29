using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public Pokemon item;
    public Image image;
    public Image imagenData;
    public Text textoData;
    public Text life;
    public Text type;
    public Sprite defaultSprite;
    
    void Start()
    {
        
    }

    public void SetItem(Pokemon item)
    {
        this.item = item;
        if(image != null && item != null)
        {
            image.enabled = true;
            image.sprite = item.icon;
            imagenData.enabled = false;
            textoData.text = item.name;
            type.text = item.type;
            life.text = ""+item.hpA.ToString()+"/"+item.hp.ToString();
        }
    }

    public void Clear()
    {
        this.item = null;
        //image.sprite = defaultSprite;
        image.enabled = false;
    }

    public void UseItem()
    {
        if (this.item != null)
        {
            item.Use();
        }
    }
}
