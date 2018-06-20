using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiBlastDestroy : MonoBehaviour {

    public Transform KiBlast;
    public float collissionRadius = 0.4f;
    public bool collided = false;
    public LayerMask whatCollideWith;
    public bool isDamaged;
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

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (whatCollideWith == (whatCollideWith | (1 << coll.gameObject.layer)))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.CompareTag("Enemy") && !isDamaged)
        {
            
            Debug.Log("Jest i on");
            EnemyThrash enemy = coll.gameObject.GetComponent<EnemyThrash>();
            enemy.Damage(PlayerPrefs.GetInt("KiDmg"));
            Destroy(gameObject);
            isDamaged = true;

        }
    }

}
