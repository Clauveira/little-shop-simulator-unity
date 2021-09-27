using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum ItemType {
        Shirt,
        Pants,
        Shoes
    }

    public ItemType itemType;
    public int Id;
    public Color color;
    public int price;
}
