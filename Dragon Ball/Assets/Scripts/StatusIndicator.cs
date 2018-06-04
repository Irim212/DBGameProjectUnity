using UnityEngine.UI;
using UnityEngine;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    private void Start()
    {
        if(healthBarRect == null)
        {
            Debug.LogError("No health bar object");
        }
        if (healthText == null)
        {
            Debug.LogError("No health text object");
        }
    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.x);
        healthText.text =_cur.ToString();
    }

}
