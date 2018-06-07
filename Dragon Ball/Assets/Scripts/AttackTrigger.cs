using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    Player player = new Player();

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            EnemyThrash enemy = col.gameObject.GetComponent<EnemyThrash>();
            enemy.Damage(player.playerStats.meleeDmg);
        }
    }
}
