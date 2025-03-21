using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseArea : BaseInteractionArea
{
    [SerializeField] private GameObject _spawnPrefab;
    private bool _isSpawned = false;


    protected override void Start()
    {
      
    }
    public override void onInteractionStart()
    {
        base.onInteractionStart();// parentta yer alan fonksiyonlarý çaðýr

        if (!_isSpawned) {
        
        GameObject go= Instantiate(_spawnPrefab,transform.position,transform.rotation);
        GameManager.instance.OnSpawnedArea(go);
           _isSpawned = true;
        }
        
        Destroy(gameObject);
    }
}
