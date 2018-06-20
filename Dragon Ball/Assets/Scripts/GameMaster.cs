using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static int zeniEarned = 0;
    public static int dbBallBought = 0;
    public static int maxHp = 0;
    public static int maxKi = 0;
    public static int melee = 0;
    public static int kiPower = 0;

    public static void KillPlayer (Player player)
    {
        SceneManager.LoadScene(0);
        Destroy(player.gameObject);
    }

    public static void KillEnemy (EnemyThrash enemy)
    {
        zeniEarned += 10;
        Destroy(enemy.gameObject);
    }

}
