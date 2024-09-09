using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencySetter : MonoBehaviour
{
    public TMP_Text currencyText;
    public int startingCurrency = 2;
    public int currentCurrency = 2;
    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = startingCurrency;
        currencyText.text = currentCurrency.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeCurrency(int currencyChange)
    {
        currentCurrency += currencyChange;
        currencyText.text = currentCurrency.ToString();
    }
}
