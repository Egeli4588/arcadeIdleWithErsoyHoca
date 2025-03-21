using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnItemTriggered(GameObject triggeredObject);
public class Sneakers :MonoBehaviour,  IInteractable
{
    public GameObject parentObject;
    public OnItemTriggered onItemTriggered;
   
    public void onInteractionEnd()
    {
        
    }

    public void onInteractionStart()
    {

       // FindObjectOfType<PlayerCharachter>().CollectProducts(this);
       // Destroy(gameObject);
    }

    public void onInteractionStart(List<GameObject> items)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharachter pc=other.GetComponent<PlayerCharachter>();
        if (pc)
        {
            pc.CollectProducts(this);
          
        }
      
      
    }
}
