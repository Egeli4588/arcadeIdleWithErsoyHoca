using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyText;


    private void OnEnable()
    {
        FindObjectOfType<CurrencyManager>().onCoinUpdated += UpdateCurrency;
    }
    private void OnDisable()
    {
        FindObjectOfType<CurrencyManager>().onCoinUpdated -= UpdateCurrency;
    }
    public void UpdateCurrency(float amount)
    {
        _currencyText.text = "Coin :" + amount.ToString();
    }


}
