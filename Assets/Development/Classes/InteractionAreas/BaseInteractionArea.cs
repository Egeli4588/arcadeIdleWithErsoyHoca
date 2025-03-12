using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractionArea : MonoBehaviour, IInteractable
{

    protected virtual void  Start()
    {
        
    }
    public virtual void onInteractionStart()
    {
        
    }
}
