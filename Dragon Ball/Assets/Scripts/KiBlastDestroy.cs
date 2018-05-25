using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBlastDestroy : MonoBehaviour {

    public Transform KiBlast;
    public float collissionRadius = 0.4f;
    public bool collided = false;
    public LayerMask whatCollideWith;
    Renderer renderer;

    private void Start()
    {
        this.renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if(this.renderer != null && !this.renderer.isVisible)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
       
        if(whatCollideWith == (whatCollideWith | (1 << coll.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
