using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    const int GravityScaleStandard = 5;
    Timer flyItemTimer;

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

    // Health bar
    [SerializeField] HealthBarController healthBar;

    public float jumpforce = 0f;
    public float jumpHigh = 5f;
    public int animateState = 0;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource collectSound;
    public AudioSource mainSound;
    private bool checkStartJumb = false;
    DateTime time;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainSound.Play();
        rbd2d = GetComponent<Rigidbody2D>();
        flyItemTimer = gameObject.AddComponent<Timer>();
        armor.SetActive(false);
        flyItemTimer.Duration = 3;

        healthBar = GameObject.FindWithTag("HealthbarTag").GetComponent<HealthBarController>();
        // Set healthbar at start
        ShowHealthBar();
        healthBar.SetHealthBar(this.hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (flyItemTimer.Finished)
        {
            rbd2d.gravityScale = GravityScaleStandard;
        }

    }

    private void FixedUpdate()
    {
        MoveCharactor();
    }

    public void MoveCharactor()
    {
        Animator mainAnimator = GetComponent<Animator>();

        groundIsTouching = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (groundIsTouching && checkStartJumb == true)
        {
            mainAnimator.SetTrigger("stayTr");
            checkStartJumb = false;
        }

        if (groundIsTouching)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && (DateTime.Now - time).Duration().TotalSeconds >= 0.35 && gameObject.transform.position.x >= -1)
            {
                checkStartJumb = true;
                jumpSound.Play();
                GetComponent<SpriteRenderer>().flipX = false;
                mainAnimator.SetTrigger("jumpTr");
                rbd2d.velocity = new Vector2(-4.5f, 14f);
                time = DateTime.Now;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && (DateTime.Now - time).Duration().TotalSeconds >= 0.35 && gameObject.transform.position.x <= 1)
            {
                checkStartJumb = true;
                GetComponent<SpriteRenderer>().flipX = true;
                mainAnimator.SetTrigger("jumpTr");
                jumpSound.Play();
                rbd2d.velocity = new Vector2(4.5f, 14f);
                time = DateTime.Now;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && (DateTime.Now - time).Duration().TotalSeconds >= 0.35)
            {
                checkStartJumb = true;

                mainAnimator.SetTrigger("jumpTr");
                jumpSound.Play();
                rbd2d.velocity = new Vector2(0, 14f);
                time = DateTime.Now;
            }
        }
    }

    public void MoveHandel(GameObject character, GameObject platform)
    {
        Animator mainAnimator = GetComponent<Animator>();

        groundIsTouching = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (groundIsTouching && checkStartJumb == true)
        {
            mainAnimator.SetTrigger("stayTr");
            checkStartJumb = false;
        }

        if (groundIsTouching)
        {
            if (platform.name == "MainPlatform2(Clone)")
            {
                if (Instance.hp >= 2)
                {
                    Instance.hp -= 1;
                }
                else
                {
                    GameOver();
                }
            }
            else if (platform.name == "MainPlatform3(Clone)")
            {
                if (Instance.hp >= 3)
                {
                    Instance.hp -= 2;
                }
                else
                {
                    GameOver();
                }
            }

        }
    }


    void Jump()
    {
        rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpforce);
    }


    /// <summary>
    /// Destroy character when falling
    /// </summary>
    private void OnBecameInvisible()
    {
        GameOver();
    }

    public void GameOver()
    {
        mainSound.Stop();
        deathSound.Play();

        GameController.Instance.GameOverUI();
        AddMoreHp(-1 * this.hp);
        Destroy(gameObject);
    }

    public void AddMoreHp(int hp)
    {
        int newHp = this.hp + hp;
        if (newHp <= MaxHp)
        {
            this.hp = newHp;
        }

        if (healthBar != null)
        {
            healthBar.SetHealthBar(this.hp);
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
                AddMoreHp(-1);
            }

            // Destory enemy after collide
            Destroy(collision.gameObject);
            if (hp <= 0)
            {
                mainSound.Stop();
                deathSound.Play();
                GameController.Instance.GameOverUI();
                Destroy(gameObject);
            }

            // Remove armor after collide
            armor.SetActive(false);
            hasArmor = false;
        }
    }

    void PickUpItems(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                collectSound.Play();
                print("Hit: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        ApplyCoinItemEffect(hitObject);
                        break;
                    case Item.ItemType.HEALTH:
                        ApplyHealthItemEffect();
                        break;
                    case Item.ItemType.ARMOR:
                        ApplyArmorItemEffect();
                        break;
                    case Item.ItemType.FLY:
                        ApplyFlyItemEffect();
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
        armor.SetActive(true);
    }

    void ApplyFlyItemEffect()
    {
        //rbd2d.gravityScale = 0;
        flyItemTimer.Run();
    }

    void HideHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(0, 0);
        }
    }

    void ShowHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(5, 5);
        }
    }
}
