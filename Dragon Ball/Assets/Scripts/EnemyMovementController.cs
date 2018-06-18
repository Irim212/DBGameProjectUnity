using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float speed = 1f;
    public float distance;

    private float rayCastOffset;

    private bool movingRight = true;

    bool attack = false;
    Vector2 startCast, endCast, meleeCast, kiCast;

    Animator enemyAnimator;

    public GameObject enemyGraphics;
    public GameObject player;
    public Canvas canvas;
    public Transform groundDetection;
    

    RaycastHit2D groundInfo, enemyView, enemyMelee, enemyKiBlast;

    //facing
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 0.5f;
    float nextFlipChance = 0f;

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        enemyAnimator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D cellCollider = GetComponent<BoxCollider2D>();
        rayCastOffset = cellCollider.bounds.extents.x / 2 + 0.3f;
    }

    // Update is called once per frame
    void Update() {

        startCast = transform.position;
        startCast.x += rayCastOffset;
        endCast = startCast;
        endCast.x -= 12.0f;
        meleeCast = startCast;
        meleeCast.x -= 2f;

        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        /*
        //WALK LINE
        if (attack == false)
        {
            if(movingRight==true)
            {
                enemyView = Physics2D.Raycast(startCast, endCast * -1);
            }
            else{
                enemyView = Physics2D.Raycast(startCast, endCast);
            }
            
            if (enemyView.collider != null)
            {
                if (enemyView.collider.name == "Player")
                {
                    //move to player
                    Debug.Log("Player w zasiegu chodzenia");
                }
            }
        }

        //ATTACK LINE
        if (movingRight == true)
        {
            Vector2 endPoint = startCast;
            endPoint.x -= 2.5f;
            enemyMelee = Physics2D.Raycast(startCast, Vector2.left, 2.5f);
            Debug.DrawLine(startCast, endPoint);
        }
        else
        {
            Vector2 endPoint = startCast;
            endPoint.x += 2.5f;
            enemyMelee = Physics2D.Raycast(startCast, Vector2.right, 2.5f);
            Debug.DrawLine(startCast, endPoint);
        }
        if (enemyMelee.collider != null)
        {
            if(enemyMelee.collider.name == "Player")
            {
                if(attack == false)
                {
                    attack = true;
                    //Bug attack player
                    Debug.Log("Player w zasięgu melee");
                }
            } else
            {
                attack = false;
            }
            Debug.Log(enemyMelee.collider.name);
        } */

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                flipGUI();
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                flipGUI();
            }
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer  < 2f)
        {
            Debug.Log("JEST TUTAJ PLEJER");
        }




        /*
        if (Time.time > nextFlipChance)
         {
             if (Random.Range(0, 10) >= 3)
            {
                if (!facingRight && player.transform.position.x < transform.position.x)
                {
                    flipFacing();
                }
                else if (facingRight && player.transform.position.x > transform.position.x)
                {
                    flipFacing();
                }
            }
             nextFlipChance = Time.time + flipTime;
         }*/

    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
    }

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphics.transform.localScale.x;
        float facingXCanvas = canvas.transform.localScale.x;
        facingX *= -1f;
        facingXCanvas *= -1f;
        enemyGraphics.transform.localScale = new Vector3(facingX, enemyGraphics.transform.localScale.y, enemyGraphics.transform.localScale.z);
        canvas.transform.localScale = new Vector3(facingXCanvas, canvas.transform.localScale.y, canvas.transform.localScale.z);
        facingRight = !facingRight;

    }

    void flipGUI()
    {
        float facingXCanvas = canvas.transform.localScale.x;
        facingXCanvas *= -1f;
        canvas.transform.localScale = new Vector3(facingXCanvas, canvas.transform.localScale.y, canvas.transform.localScale.z);
    }
}
