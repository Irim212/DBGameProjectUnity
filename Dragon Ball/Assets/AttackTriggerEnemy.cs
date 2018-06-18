using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemy : MonoBehaviour {

    EnemyThrash enemy = new EnemyThrash();



    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            Debug.Log("WALE PLEJERA");
            Player player = col.gameObject.GetComponent<Player>();
            player.Damage(10);
        }
    }
}
