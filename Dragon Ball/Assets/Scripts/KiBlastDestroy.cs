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

    Player player = new Player();


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

        if (whatCollideWith == (whatCollideWith | (1 << coll.gameObject.layer)))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.name.Equals("Enemy")&& !isDamaged)
        {
            
            Debug.Log("Jest i on");
            EnemyThrash enemy = coll.gameObject.GetComponent<EnemyThrash>();
            enemy.Damage(player.playerStats.kiBlastDmg);
            Destroy(gameObject);
            isDamaged = true;

        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        isDamaged = false;
    }

}
