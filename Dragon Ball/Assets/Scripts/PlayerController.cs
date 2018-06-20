using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [Range(1, 10)]
    Rigidbody2D rb;
    public int jumpAmount = 0;
    public float jumpVelocity;
    public float maxSpeed = 3f;
    public float jumpForce = 3f;

    //animator - obsługuje przejścia animatora
    Animator anim;

    Player player = new Player();

    public Collider2D attackTrigger;
    
    //zmienne sprawdzania uziemienia
    bool holdAtk = false;
    bool canWalk = true;
    bool grounded = false;
    bool kiHold = false;
    bool guard = false;
    public static bool kiBlastHold = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public static bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); // (pozycja, średnica koła, rodzja podłoża)
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetBool("kiHold", kiHold);
        anim.SetBool("guardHold", guard);
        anim.SetBool("holdAtk", holdAtk);
        anim.SetBool("KiBlastHold", kiBlastHold);
        

        float horizontalMove = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (canWalk == true)
            rb.velocity = new Vector2(horizontalMove * maxSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            
            if (jumpAmount <= 1)
            {
                grounded = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
                jumpAmount++;
            }
        }

        //Transform
        if(Input.GetKeyDown(KeyCode.K) && player.playerStats.currentKi >= 100)
        {
            anim.SetTrigger("Transform");
        }



        //KI LOADING
        if (Input.GetKeyDown(KeyCode.L))
        {
            canWalk = false;
            kiHold = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }else if(Input.GetKeyUp(KeyCode.L))
        {
            kiHold = false;  
            canWalk = true;
        }

        //KI BLAST
        if (Input.GetKeyDown(KeyCode.O))
        {
            if(!kiHold && !guard && player.playerStats.currentKi>10)
            {
                kiBlastHold = true;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.O)) kiBlastHold = false;

        else if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.O))
        {
            kiHold = false;
            canWalk = true;
        }

        //GUARD
        if (Input.GetKeyDown(KeyCode.P))
        {
            canWalk = false;
            rb.velocity = new Vector2(0, 0);
            guard = true;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            canWalk = true;
            guard = false;
        }

        //ATTACK MELEE
        if (Input.GetKeyDown(KeyCode.I))
        {
            holdAtk = true;
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            holdAtk = false;
        }


        if (rb.velocity.y == 0)
        {
            jumpAmount = 0;
            grounded = true;

        } else if (rb.velocity.y != 0 )
        {
            grounded = false;
        }

        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }

    }

    void Attack()
    {
        attackTrigger.enabled = true;
    }

    void noAttack()
    {
        attackTrigger.enabled = false;
    }

    void addKi()
    {
        player.playerStats.currentKi += 1;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}