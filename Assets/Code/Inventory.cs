using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory
{
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { Id = 1, color = new Color(1f, 0.92f, 0.016f, 1f) } );
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }
}
