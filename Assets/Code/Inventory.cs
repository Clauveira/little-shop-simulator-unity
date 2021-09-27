using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int maxItems = 8;
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

    public void setMaxItems(int new_value){
        maxItems = new_value;
    }

    public bool getIsFull(){
        return itemList.Count >= maxItems;
    }
}
