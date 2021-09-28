using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSlotContainer : MonoBehaviour
{
    public Player player;
    public Item item = new Item();
    public int ID = 0;

    public void setItem(Item _item){
        item = _item;
    }
    public void setID(int id){
        ID = id;
    }

    public void onClick(){
        player.equipeItem(ID);
    }
}
