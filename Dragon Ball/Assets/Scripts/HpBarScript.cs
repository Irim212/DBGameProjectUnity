using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour {

    public float fillAmount;

    public Image content;

    public float maxHp;
    public float amountHp = Player.PlayerStats._currentHealth;


	// Use this for initialization
	void Start () {
        maxHp = PlayerPrefs.GetInt("MaxHP"); 
        Player.PlayerStats.playerChange += (newHealth) =>
        {
            amountHp = newHealth;
        };
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
        amountHp = Player.PlayerStats._currentHealth;
        fillAmount = Mathf.Lerp(0, 1, amountHp / maxHp);
    }

    private void HandleBar()
    {
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float MappingAmount (float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
