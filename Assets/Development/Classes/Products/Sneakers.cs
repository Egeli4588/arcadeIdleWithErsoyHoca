using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneakers :MonoBehaviour,   IInteractable
{
    public void onInteractionStart()
    {

        FindObjectOfType<PlayerCharachter>().CollectProducts(this);
       // Destroy(gameObject);
    }
}
