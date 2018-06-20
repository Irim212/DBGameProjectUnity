using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public int zeni = 100;
        public int dbBalls = 100;

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

        public int maxHP
        {
            get { return MaxHP; }
            
            set { MaxHP = value; }
        }

        public int maxKI
        {
            get { return MaxKi; }
            
            set { MaxKi = value; }
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
        Debug.Log(playerStats.maxHP);
        Debug.Log(PlayerStats.MaxHP);
        playerStats.currentHealth -= dmgAmount;
        PlayerStats.playerChange(playerStats.currentHealth);
        if(playerStats.currentHealth <= 0)
        {
            addZeni(GameMaster.zeniEarned);
            addDBBalls(GameMaster.dbBallBought);
            addHP(GameMaster.maxHp);
            addKi(GameMaster.maxKi);
            addKiPower(GameMaster.kiPower);
            addMeleeDmg(GameMaster.melee);


            SavePlayerData();
            Debug.Log(playerStats.meleeDmg);
            Debug.Log(PlayerPrefs.GetInt("MeleeDmg"));
            GameMaster.KillPlayer(this);
            SceneManager.LoadScene(0);
        }
    }

    public void KiUse(int kiAmount)
    {
        playerStats.currentKi -= kiAmount;
        PlayerStats.playerChange(playerStats.currentKi);
        
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("MaxKi", playerStats.maxKI);
        PlayerPrefs.SetInt("MaxHP", playerStats.maxHP);
        PlayerPrefs.SetInt("KiDmg", playerStats.kiBlastDmg);
        PlayerPrefs.SetInt("MeleeDmg", playerStats.meleeDmg);
        PlayerPrefs.SetInt("Zeni", playerStats.zeni);
        PlayerPrefs.SetInt("DBBalls", playerStats.dbBalls);
    }

    public void LoadPlayerData()
    {
        playerStats.maxHP = PlayerPrefs.GetInt("MaxHP");
        playerStats.maxKI = PlayerPrefs.GetInt("MaxKi");
        playerStats.kiBlastDmg = PlayerPrefs.GetInt("KiDmg");
        playerStats.meleeDmg = PlayerPrefs.GetInt("MeleeDmg");
        playerStats.zeni = PlayerPrefs.GetInt("Zeni");
        playerStats.dbBalls = PlayerPrefs.GetInt("DBBalls");
        playerStats.Init();
    }

    public void addZeni(int amount)
    {
        playerStats.zeni += amount;
    }

    public void addDBBalls (int amount)
    {
        playerStats.dbBalls += amount;
    }

    public void addMeleeDmg (int amount)
    {
        playerStats.meleeDmg += amount;
    }

    public void addKiPower(int amount)
    {
        playerStats.kiBlastDmg += amount;
    }

    public void addHP(int amount)
    {
        playerStats.maxHP += amount;
    }

    public void addKi(int amount)
    {
        playerStats.maxKI += amount;
    }
}
