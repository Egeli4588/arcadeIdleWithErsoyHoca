using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
  public  void onInteractionStart();
    public void onInteractionStart(List<GameObject> items);
    public void onInteractionEnd();
}
