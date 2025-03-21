using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnItemCollected(Sneakers item, List<Sneakers> itemlist);
public delegate void OnItemRemoved(Sneakers item);
public class PlayerCharachter : BaseCharachter
{
    private List<Sneakers> collectedProducts = new();

    public OnItemCollected onItemCollected;
    public OnItemRemoved onItemRemoved;
    protected override void onEnable()
    {
        base.onEnable();
      
    }
    protected override void onDisable()
    {
        base.onDisable();
      
    }
    public void CollectProducts(Sneakers item)
    {
        collectedProducts.Add(item);

        onItemCollected?.Invoke(item,collectedProducts);
    

        item.transform.position = transform.position + (transform.up * (2 + collectedProducts.Count));
        item.transform.parent = transform;
    }



    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && other.transform.GetComponent<Shelf>())
        {
            List<GameObject> tempItems = new();

            for (int i = collectedProducts.Count - 1; i >= 0; i--)
            {

                tempItems.Add(collectedProducts[i].gameObject);

            }

            interactable.onInteractionStart(tempItems);

        }
    }
    public void RemoveProductFromCollection(Sneakers removeItem)
    {

        for (int i = 0; i < collectedProducts.Count; i++)
        {
            if (collectedProducts[i] == removeItem)
            {
                collectedProducts.RemoveAt(i);
                onItemRemoved?.Invoke(removeItem);
            }
        }




    }


}
