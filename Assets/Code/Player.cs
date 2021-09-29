using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    public Rigidbody2D playerRigidbody;
    public Animator animator;
    public CustomizableSprites characterSprites;

    Vector2 movement;

    [SerializeField] private UI_Inventory uiBuyingInventory;
    [SerializeField] private UI_Inventory uiPlayerInventory;

    private Inventory buyingInventory;
    private Inventory playerInventory;



    void Start()
    {
    }
    void Update()
    {
        Move();
        Animate();
    }

    public void transferToPersonalInventory(){
        foreach(Item new_item in buyingInventory.GetItemList()){
            playerInventory.AddItem(new_item);
        }
        buyingInventory.clearInventory();
    }

    private void Awake(){
        buyingInventory = new Inventory();
        uiBuyingInventory.SetInventory(buyingInventory);

        playerInventory = new Inventory();
        uiPlayerInventory.SetInventory(playerInventory);
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Animate()
    {
        if (movement.sqrMagnitude > 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            if (movement.x == 0)
            {
                animator.SetFloat("Vertical", movement.y);
            }
            else
            {
                animator.SetFloat("Vertical", 0);
            }
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    public Inventory getInventory(){
        return buyingInventory;
    }

    public void equipeItem(int itemId){
        characterSprites.setItemAparence(playerInventory.GetItemList()[itemId]);
        //SpriteRenderer sprite = transform.Find("Sprites/Body/Shirt").GetComponent(typeof(Sprite));
        //sprite.color = item.color;

    }
}
