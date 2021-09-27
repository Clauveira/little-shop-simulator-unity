using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    public Rigidbody2D rigidbody;
    public Animator animator;

    Vector2 movement;

    [SerializeField] private UI_Inventory uiBuyingInventory;

    private Inventory buyingInventory;


    void Start()
    {
    }
    void Update()
    {
        Move();
        Animate();
    }

    private void Awake(){
        buyingInventory = new Inventory();
        uiBuyingInventory.SetInventory(buyingInventory);
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
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    public Inventory getInventory(){
        return buyingInventory;
    }
}
