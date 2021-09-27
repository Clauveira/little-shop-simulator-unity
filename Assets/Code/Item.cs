using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum ItemType {
        None,
        Shirt,
        Pants,
        Shoes,
    }

    public ItemType itemType;
    public int Id;
    public Color color;
    public int price;

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.None: return ItemAssets.Instance.noSprite;
            case ItemType.Shirt: return ItemAssets.Instance.shirtsSprite;
            case ItemType.Pants: return ItemAssets.Instance.pantsSprite;
            case ItemType.Shoes: return ItemAssets.Instance.shoesSprite;
        }
    }

    public void Randomize(){
        Id = 0;
        itemType = (ItemType)Random.Range(1, 4);
        color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
        price = Random.Range(190, 300);
    }
    public void Buy(){
        Id = 0;
        itemType = ItemType.None;
        color = new Color(1f,0.99f,0.9f);
        price = 0;
    }

}
