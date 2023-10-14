using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Slider sliding;
    public Image fill;
    public TMP_Text healthPercent;
    // Start is called before the first frame update
    void Start()
    {
        sliding.maxValue = 100f;
        sliding.value = sliding.maxValue;
    }

    // Update is called once per frame
    public void UpdateValue(float damage)
    {
        sliding.fillRect.gameObject.SetActive(true);
        sliding.value -= damage;
        healthPercent.text = (Mathf.CeilToInt(sliding.value).ToString());
    }
}
