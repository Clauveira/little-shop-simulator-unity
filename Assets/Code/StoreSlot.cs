using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StoreSlot : MonoBehaviour
{
    
    private Transform Player;
    public Button button;
    public SpriteRenderer sprite;
    private float actualDistance;
    private float minimumDistance = 1f;

    private bool is_sold = false;

    private Item item = new Item();
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        item.Randomize();
        sprite.sprite = item.GetSprite();
        sprite.color = item.color;
    }

    void Update()
    {
        actualDistance = Vector2.Distance(transform.position, Player.position);
        if (!button.interactable  && !is_sold && actualDistance <= minimumDistance){
            button.interactable = true;
        } else if (button.interactable && actualDistance > minimumDistance) {
            button.interactable = false;
        }
    }

    public void tryBuy(){
        /*
        SendMessageUpwards("AddBuyingItem", item);
        item = new Item();
        item.Buy();
        sprite.sprite = item.GetSprite();
        sprite.color = item.color;
        is_sold = true;
        button.interactable = false;*/
        //sprite.sprite = null;

        SendMessageUpwards("AddBuyingItem", this);
    }

    public void saleAccepted(){
        item = new Item();
        item.Buy();
        sprite.sprite = item.GetSprite();
        sprite.color = item.color;
        is_sold = true;
        button.interactable = false;
    }

    public Item getItem(){
        return item;
    }
    



}
