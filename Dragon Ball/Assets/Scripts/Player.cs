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
        public static int MaxKi = 100;
        public static int _currentKi = 100;
        public int kiBlastCost = 10;
        public int meleeDmg = 10;
        public int kiBlastDmg = 25;

        public static Action<int> playerChange;

        public int currentHealth
        {
            get { return _currentHealth;}

            set { _currentHealth = Mathf.Clamp(value, 0, MaxHP);}
        }

        public int currentKi
        {
            get { return _currentKi; }

            set { _currentKi = Mathf.Clamp(value, 0, MaxKi);}
        }

        public void Init()
        {
            currentHealth = MaxHP;
            currentKi = MaxKi;
        }
        
    }

    public PlayerStats playerStats = new PlayerStats();
    public int fallBoundary = -20;

    void Update()
    {
        if(transform.position.y <= fallBoundary)
        {
            Damage(10);
        }        
    }

    public void Damage(int dmgAmount)
    {
        playerStats.currentHealth -= dmgAmount;
        PlayerStats.playerChange(playerStats.currentHealth);
        if(playerStats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
            Debug.Log("You are dead");
        }
    }

    public void KiUse(int kiAmount)
    {
        playerStats.currentKi -= kiAmount;
        PlayerStats.playerChange(playerStats.currentKi);
        
    }
}
