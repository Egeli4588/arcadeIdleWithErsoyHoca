using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharachter : BaseCharachter
{
    private List<Sneakers> collectedProducts= new();
    public void CollectProducts(Sneakers item)
    {
        collectedProducts.Add(item);
        item.transform.position = transform.position + (transform.up*(2+collectedProducts.Count));
        item.transform.parent = transform;
    }
}
