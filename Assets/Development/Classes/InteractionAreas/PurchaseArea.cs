using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseArea : BaseInteractionArea
{
    [SerializeField] private GameObject _spawnPrefab;



    protected override void Start()
    {
      
    }
    public override void onInteractionStart()
    {
        base.onInteractionStart();// parentta yer alan fonksiyonlarý çaðýr

        Instantiate(_spawnPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
