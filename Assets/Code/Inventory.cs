using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private int maxItems = 8;
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
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

    public void clearInventory(){
        itemList.Clear();
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
