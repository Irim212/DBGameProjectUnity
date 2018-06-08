using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiBarScript : MonoBehaviour {

    public float fillAmount;

    public Image content;

    public float maxKi = Player.PlayerStats.MaxKi;
    public float amountKi = Player.PlayerStats._currentKi;


    // Use this for initialization
    void Start()
    {
        Player.PlayerStats.playerChange += (newKi) =>
        {
            amountKi = newKi;
        };
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
        amountKi = Player.PlayerStats._currentKi;
        fillAmount = Mathf.Lerp(0, 1, amountKi / maxKi);
    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float MappingAmount(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
