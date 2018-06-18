using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrash : MonoBehaviour {

    [System.Serializable]
    public class EnemyStat
    {
        public static int level = 1;
        public int MaxHP = 100 * level;
        private int _currentHealth;
        public int damage = 10 * level;

        public static Action<int> enemyHealthChange = changeEnemyHealth;

        private static void changeEnemyHealth(int newHealth)
        {

        }

        public int currentHealth
        {
            get { return _currentHealth; }

            set { _currentHealth = Mathf.Clamp(value, 0, MaxHP); }
        }

        public void Init()
        {
            currentHealth = MaxHP;
        }
    }

    public EnemyStat enemyStat = new EnemyStat();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        enemyStat.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStat.currentHealth, enemyStat.MaxHP);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Damage(int dmgAmount)
    {
        enemyStat.currentHealth -= dmgAmount;
        EnemyStat.enemyHealthChange(enemyStat.currentHealth);
        if (enemyStat.currentHealth <= 0)
        {
            GameMaster.KillEnemy(this);
            Debug.Log("Enemy is dead");
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStat.currentHealth, enemyStat.MaxHP);
        }
    }
}
