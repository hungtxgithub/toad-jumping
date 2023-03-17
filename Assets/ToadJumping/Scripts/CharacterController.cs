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
    public float jumpSpeed = 4f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool groundIsTouching;
    public int hp = 1;
    public const int MaxHp = 5;

    // Item effect
    private bool hasArmor = false;
    [SerializeField] GameObject armor;

    public float jumpforce = 0f;
    public float jumpHigh = 5f;
    public int animateState = 0;
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
        // moveInput = Input.GetAxis("Horizontal");
        // rbd2d.velocity = new Vector2(moveInput * speed, rbd2d.velocity.y);
       Animator  mainAnimator=   GetComponent<Animator>();

        groundIsTouching = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        //if (groundIsTouching)
        //{

        if (!groundIsTouching && jumpforce==6f)
        {
             

             if (rbd2d.transform.position.x<=-2 ||rbd2d.transform.position.x>=2){
                 Debug.Log(" dung: " + rbd2d.transform.position.x);
                jumpforce =0f;
                rbd2d.velocity = new Vector2( 0f, rbd2d.velocity.y); 
             }
             if(rbd2d.transform.position.x>=-0.1f&&rbd2d.transform.position.x<=0.1f){
               
                 Debug.Log(" dung: " + rbd2d.transform.position.x);
                jumpforce =0f;
                rbd2d.velocity = new Vector2( 0f, rbd2d.velocity.y); 
             }
        }

        // if (groundIsTouching)
        // {
        //    GetComponent<Rigidbody2D>().gravityScale = 0;
        //}
        //else
        //{
        //    GetComponent<Rigidbody2D>().gravityScale = 1;
        //}

        if (Input.GetButtonDown("Jump") && groundIsTouching)
        // }
         if (groundIsTouching && jumpforce==6f)
        {
            mainAnimator.SetTrigger("stayTr");

        armor.SetActive(hasArmor);
        }
        
           
        if (  groundIsTouching)
        {
          jumpforce = 6f;
           if(Input.GetKey(KeyCode.LeftArrow)){
                rbd2d.velocity = new Vector2( -jumpforce, jumpSpeed); //for left jumping
                
                mainAnimator.SetTrigger("jumpTr");
                GetComponent<SpriteRenderer>().flipX = true;

            }
            if(Input.GetKey(KeyCode.RightArrow)){
                rbd2d.velocity = new Vector2( jumpforce, jumpSpeed); //for right jumping
                mainAnimator.SetTrigger("jumpTr");
                GetComponent<SpriteRenderer>().flipX = false;


            }
            if(Input.GetButtonDown("Jump")){
            rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpSpeed);
            }
        }
        
    }

    /// <summary>
    /// Destroy character when falling
    /// </summary>
    private void OnBecameInvisible()
    {
        GameController.Instance.GameOverUI();
        Destroy(gameObject);
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
