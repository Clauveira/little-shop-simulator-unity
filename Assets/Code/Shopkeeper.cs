using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shopkeeper : MonoBehaviour, IPointerDownHandler
{
    public GameObject emote;
    private GameObject playerObj;
    private Player player;
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        player = (Player)playerObj.GetComponent(typeof(Player));
    }

    public void OnPointerDown(PointerEventData eventData){
        if (Vector2.Distance(transform.position, playerObj.transform.position) <= 2){
            sellAll();
            emote.SetActive(true);
        }
    }

    public void sellAll()
    {
        player.transferToPersonalInventory();
    }
}
