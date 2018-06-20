using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataToMenu : MonoBehaviour {

    [SerializeField]
    private Text Zeni;

    [SerializeField]
    private Text DBBall;

    [SerializeField]
    private Text HP, KI, Melee, KiPower;

    public int zeni, dbBalls, hp, ki, melee, kiPower;

    // Use this for initialization
    void Start () {
        zeni = PlayerPrefs.GetInt("Zeni");
        dbBalls = PlayerPrefs.GetInt("DBBalls");
        hp = PlayerPrefs.GetInt("MaxHP");
        ki = PlayerPrefs.GetInt("MaxKi");
        melee = PlayerPrefs.GetInt("MeleeDmg");
        kiPower = PlayerPrefs.GetInt("KiDmg");

    }
	
	// Update is called once per frame
	void Update () {


        Zeni.text = zeni.ToString();
        DBBall.text = dbBalls.ToString();
        HP.text = hp.ToString();
        KI.text = ki.ToString();
        Melee.text = melee.ToString();
        KiPower.text = kiPower.ToString();
	}

    public void addBalls50()
    {
        dbBalls += 50;
        GameMaster.dbBallBought += 50;
        PlayerPrefs.SetInt("DBBalls", dbBalls);
        dbBalls = PlayerPrefs.GetInt("DBBalls");
        DBBall.text = dbBalls.ToString();
    }

    public void addBalls100()
    {
        dbBalls += 100;
        GameMaster.dbBallBought += 100;
        PlayerPrefs.SetInt("DBBalls", dbBalls);
        dbBalls = PlayerPrefs.GetInt("DBBalls");
        DBBall.text = dbBalls.ToString();
    }

    public void addBalls250()
    {
        dbBalls += 250;
        GameMaster.dbBallBought += 250;
        PlayerPrefs.SetInt("DBBalls", dbBalls);
        dbBalls = PlayerPrefs.GetInt("DBBalls");
        DBBall.text = dbBalls.ToString();
    }

    public void hpUpgrade()
    {
        if (zeni >= 10)
        {
            hp += 5;
            GameMaster.maxHp += 5;
            PlayerPrefs.SetInt("MaxHP", hp);
            hp = PlayerPrefs.GetInt("MaxHP");
            HP.text = hp.ToString();

            zeni -= 10;
            GameMaster.zeniEarned -= 10;
            PlayerPrefs.SetInt("Zeni", zeni);
            zeni = PlayerPrefs.GetInt("Zeni");
            Zeni.text = zeni.ToString();
        }
        else
        {
            Debug.Log("Brak Zeni!");
        }
    }

    public void kiUpgrade()
    {
        if (zeni >= 10)
        {
            ki += 5;
            GameMaster.maxKi += 5;
            PlayerPrefs.SetInt("MaxKi", ki);
            ki = PlayerPrefs.GetInt("MaxKi");
            KI.text = ki.ToString();

            zeni -= 10;
            GameMaster.zeniEarned -= 10;
            PlayerPrefs.SetInt("Zeni", zeni);
            zeni = PlayerPrefs.GetInt("Zeni");
            Zeni.text = zeni.ToString();
        }
        else
        {
            Debug.Log("Brak Zeni!");
        }
    }

    public void meleeUpgrade()
    {
        if(zeni>=10)
        {
            melee += 1;
            GameMaster.melee += 1;
            PlayerPrefs.SetInt("MeleeDmg", melee);
            melee = PlayerPrefs.GetInt("MeleeDmg");
            Melee.text = melee.ToString();

            zeni -= 10;
            GameMaster.zeniEarned -= 10;
            PlayerPrefs.SetInt("Zeni", zeni);
            zeni = PlayerPrefs.GetInt("Zeni");
            Zeni.text = zeni.ToString();
        }else
        {
            Debug.Log("Brak Zeni!");
        }

    }

    public void kiPowerUpgrade()
    {
        if (zeni >= 10)
        {
            kiPower += 5;
            GameMaster.kiPower += 5;
            PlayerPrefs.SetInt("KiDmg", kiPower);
            kiPower = PlayerPrefs.GetInt("KiDmg");
            KiPower.text = ki.ToString();

            zeni -= 10;
            GameMaster.zeniEarned -= 10;
            PlayerPrefs.SetInt("Zeni", zeni);
            zeni = PlayerPrefs.GetInt("Zeni");
            Zeni.text = zeni.ToString();
        }
        else
        {
            Debug.Log("Brak Zeni!");
        }
    }
}
