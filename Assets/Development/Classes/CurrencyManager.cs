using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCoinUpdate(float Coin);
public class CurrencyManager : MonoBehaviour
{
    [SerializeField]
    private float currentCurrency = 500f;

    public OnCoinUpdate onCoinUpdated;
    private void Start()
    {
        FindObjectOfType<UIManager>().UpdateCurrency(currentCurrency);
    }

    public void UpdateCoin(float amount)

    {
        currentCurrency += amount;
        onCoinUpdated?.Invoke(currentCurrency);
    }

    public bool isEnoughCurrency(float price)
    {
        return currentCurrency >= price;
    }
}