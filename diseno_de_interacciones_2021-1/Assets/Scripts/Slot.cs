using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemAR item;
    public Image image;
    public Sprite empty;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetItem(ItemAR item){
        this.item = item;
        if(image != null){
            //image.enabled = true;
            image.sprite = item.icon;
        }
    }

    public void Clear(){
        this.item = null;
        image.sprite = empty;
        //image.enabled = false;
    }
}
