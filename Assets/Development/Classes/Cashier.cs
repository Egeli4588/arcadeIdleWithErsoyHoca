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
    [SerializeField] private Transform _queueTransform;
    [SerializeField] private List<GameObject> _queueList = new();

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
        for (int j = 0; j < cashierMaps.Count; j++) 
        
        {
            if (cashierMaps[j].cashierObject !=null)
            {
                result.Add(cashierMaps[j].cashierObject);
                CashierMap tempMap = new CashierMap(cashierMaps[j].cashierTransform, null);
                cashierMaps[j] = tempMap;
            }
        }

        return result;
    }

    public void AddCustomerToQueue(GameObject customer)
    {

        _queueList.Add(customer);
    }

    public void RemoveCustomerFromQueue(GameObject customer)
    {
        _queueList.Remove(customer);
    }


    public Vector3 GetLocationForSpecificCustomer(GameObject customer)
    {
        Vector3 newLocation = _queueTransform.position + (_queueTransform.transform.forward * (_queueList.IndexOf(customer) * 2.5f));
        return newLocation;
    }
    public int GetCustomerIndex(GameObject customer)

    {
        int result = -1;
        if (_queueList.Contains(customer))
        {
            result = _queueList.IndexOf(customer);
        }
        return result;

    }

}
