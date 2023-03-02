using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rbd2d;
    public float moveInput;
    public float speed = 2f;
    public float jumpSpeed = 5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool groundIsTouching;

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
            // moveInput = Input.GetAxis("Vertical");
            // rbd2d.velocity = new Vector2(rbd2d.velocity.x,  jumpSpeed*moveInput);

        // }

        if (Input.GetButtonDown("Jump") && groundIsTouching){
            rbd2d.velocity = new Vector2(rbd2d.velocity.x,  jumpSpeed);
        }

    }

}
