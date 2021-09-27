using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum ItemType {
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
            case ItemType.Shirt: return ItemAssets.Instance.shirtsSprite;
            case ItemType.Pants: return ItemAssets.Instance.pantsSprite;
            case ItemType.Shoes: return ItemAssets.Instance.shoesSprite;
        }
    }

    public void Rantomize(){
        Id = 0;
        itemType = (ItemType)Random.Range(0, 3);
        //color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
        price = Random.Range(190, 300);
    }
}
