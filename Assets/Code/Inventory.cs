using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory
{
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { Id = 1, color = new Color(1f, 0.92f, 0.016f, 1f), itemType = Item.ItemType.Shirt, price = 100 } );
        AddItem(new Item { Id = 2, color = new Color(0f, 1.0f, 0.016f, 1f), itemType = Item.ItemType.Pants, price = 100  } );
        AddItem(new Item { Id = 3, color = new Color(0f, 0.2f, 0.916f, 1f), itemType = Item.ItemType.Shoes, price = 100  } );
        
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }
}
