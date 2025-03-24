using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct CashierMap
{
    public Transform cashierTransform;
    public GameObject cashierObject;

    public CashierMap(Transform cashierTransform, GameObject cashierObject)
    {
        this.cashierTransform = cashierTransform;
        this.cashierObject = cashierObject;

    }

}
public class Cashier : MonoBehaviour
{
    public List<CashierMap> cashierMaps;

    public void AddProductToCashier(List<GameObject> product)
    {
        for (int j = 0; j < product.Count; j++)
        {

            for (int i = 0; i < cashierMaps.Count; i++)
            {
                if (cashierMaps[i].cashierObject == null)
                {
                    product[j].transform.position = cashierMaps[i].cashierTransform.position;
                    product[j].transform.parent = cashierMaps[i].cashierTransform;

                    CashierMap tempMap = new CashierMap(cashierMaps[i].cashierTransform, product[j]);
                    cashierMaps[i] = tempMap;

                    break;
                }
            }

        }
    }

    public List<GameObject> CollectProductsFromCashier()
    {
        List<GameObject> result = new();
        foreach (var item in cashierMaps)
        {
            if (item.cashierObject != null)
            {
                result.Add(item.cashierObject);
            }

        }

        return result;
    }

}
