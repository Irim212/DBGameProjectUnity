using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBlastFire : MonoBehaviour {

    public float velXR = 200f;
    public float velXL = -5f;
    Rigidbody2D rb;
    SpriteRenderer spriteKi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteKi = GetComponent<SpriteRenderer>();
        if (PlayerController.facingRight)
        {
            rb.velocity = new Vector2(velXR, 0);
        }
        else if (!PlayerController.facingRight)
        {
            spriteKi.flipX = true;
            rb.velocity = new Vector2(velXL, 0);
        }
    }

}

