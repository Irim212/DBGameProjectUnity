using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static void KillPlayer (Player player)
    {
        SceneManager.LoadScene(0);
        Destroy(player.gameObject);
    }

    public static void KillEnemy (EnemyThrash enemy)
    {
        Destroy(enemy.gameObject);
    }

}
