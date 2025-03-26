using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseArea : BaseInteractionArea
{
    [SerializeField] private GameObject _spawnPrefab;
    private bool _isSpawned = false;

    [SerializeField] private float _price;


    protected override void Start()
    {

    }
    public override void onInteractionStart()
    {
        base.onInteractionStart();// parentta yer alan fonksiyonlarý çaðýr

        if (!_isSpawned)
        {

            if (FindObjectOfType<CurrencyManager>().isEnoughCurrency(_price))
            {
                GameObject go = Instantiate(_spawnPrefab, transform.position, transform.rotation);
                GameManager.instance.OnSpawnedArea(go);
                _isSpawned = true;

                //Satýnalma kodu
                FindObjectOfType<CurrencyManager>().UpdateCoin(-_price);
            }
        }

        Destroy(gameObject);
    }
}
