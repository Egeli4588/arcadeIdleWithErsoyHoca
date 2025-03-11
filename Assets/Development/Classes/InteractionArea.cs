using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _spawnPrefab;
    public void onInteractionStart()
    {
        Instantiate(_spawnPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
