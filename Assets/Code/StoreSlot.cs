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

    private Item item = new Item();
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        item.Rantomize();
        sprite.sprite = item.GetSprite();
        sprite.color = item.color;
    }

    // Update is called once per frame
    void Update()
    {
        actualDistance = Vector2.Distance(transform.position, Player.position);
        if (!button.interactable && actualDistance <= minimumDistance){
            button.interactable = true;
        } else if (button.interactable && actualDistance > minimumDistance) {
            button.interactable = false;
        }
    }
}
