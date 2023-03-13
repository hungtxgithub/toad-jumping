using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static CharacterController instance;
    public static CharacterController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<CharacterController>();
            }
            return instance;
        }
    }


    private Rigidbody2D rbd2d;
    public float moveInput;
    public float speed = 2f;
    public float jumpSpeed = 5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool groundIsTouching;
    public int hp = 1;
    public const int MaxHp = 5;

    // Item effect
    private bool hasArmor = false;
    [SerializeField] GameObject armor;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.position.y 
        moveInput = Input.GetAxis("Horizontal");
        rbd2d.velocity = new Vector2(moveInput * speed, rbd2d.velocity.y);


        groundIsTouching = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // if (groundIsTouching)
        // {
        //    GetComponent<Rigidbody2D>().gravityScale = 0;
        // }else{
        //    GetComponent<Rigidbody2D>().gravityScale = 1;
        // }

        if (Input.GetButtonDown("Jump") && groundIsTouching)
        {
            rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpSpeed);
        }

        armor.SetActive(hasArmor);
    }

    /// <summary>
    /// Destroy character when falling
    /// </summary>
    private void OnBecameInvisible()
    {
        GameController.Instance.GameOverUI();
        Destroy(this);
    }

    public void AddMoreHp(int hp)
    {
        int newHp = this.hp + hp;
        if(newHp <= MaxHp)
        {
            this.hp = newHp;
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        PickUpItems(collision);
        CollideWithEnemy(collision);
	}

    void CollideWithEnemy(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Enemy"))
		{
            if (!hasArmor)
            {
                hp--;
            }

            // Destory enemy after collide
            Destroy(collision.gameObject);
			if (hp <= 0)
			{
				GameController.Instance.GameOverUI();
				Destroy(gameObject);
			}

            // Remove armor after collide
            hasArmor = false;
		}
	}

    void PickUpItems(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject  = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
				print("Hit: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN: ApplyCoinItemEffect(hitObject);
                        break;
                    case Item.ItemType.HEALTH: ApplyHealthItemEffect();
                        break;
                    case Item.ItemType.ARMOR: ApplyArmorItemEffect();
                        break;
                    default:
                        break;
                }

                // collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
			}
        }
    }

    void ApplyCoinItemEffect(Item item)
    {
        item.quantity++;
    }

	void ApplyHealthItemEffect()
	{
        AddMoreHp(1);
	}

	void ApplyArmorItemEffect()
	{
        hasArmor = true;
	}
}
