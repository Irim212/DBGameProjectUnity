using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float speed;

    Animator enemyAnimator;

    public GameObject enemyGraphics;
    public GameObject player;

    //facing
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 0.5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        enemyAnimator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

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
         }
    }

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphics.transform.localScale.x;
        facingX *= -1f;
        enemyGraphics.transform.localScale = new Vector3(facingX, enemyGraphics.transform.localScale.y, enemyGraphics.transform.localScale.z);
        facingRight = !facingRight;

    }
}
