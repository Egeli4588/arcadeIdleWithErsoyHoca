using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharachter : BaseCharachter
{
    private List<Sneakers> collectedProducts = new();
    public void CollectProducts(Sneakers item)
    {
        collectedProducts.Add(item);
        // TODO: buraya geri gelinecek
        FindObjectOfType<CollactableArea>().UpdateProductDictionary(item.gameObject);

        item.transform.position = transform.position + (transform.up * (2 + collectedProducts.Count));
        item.transform.parent = transform;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
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
            }
        }




    }


}
