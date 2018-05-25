using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        public static int MaxHP = 100;
        public static int _currentHealth = 100;
        public static int maxKi = 100;
        public static int _currentKi = 100;

        public static Action<int> playerHealthChange;

        public int currentHealth
        {
            get { return _currentHealth;}

            set { _currentHealth = Mathf.Clamp(value, 0, MaxHP);}
        }

        public int currentKi
        {
            get { return _currentKi; }

            set { _currentKi = Mathf.Clamp(value, 0, maxKi);}
        }

        public void Init()
        {
            currentHealth = MaxHP;
        }
        
    }

    public PlayerStats playerStats = new PlayerStats();
    public int fallBoundary = -20;

    void Update()
    {
        if(transform.position.y <= fallBoundary)
        {
            DamagePlayer(10);
        }

        
    }

    public void DamagePlayer(int dmgAmount)
    {
        playerStats.currentHealth -= dmgAmount;
        PlayerStats.playerHealthChange(playerStats.currentHealth);
        if(playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
            Debug.Log("You are dead");
        }
    }
}
