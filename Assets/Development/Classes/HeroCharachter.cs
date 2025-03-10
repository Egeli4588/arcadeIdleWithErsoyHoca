using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharachter : BaseHuman
{
    protected override void Move(Vector3 moveDirecton)
    {
        base.Move(moveDirecton);
    }

    protected override void OnDamageArea()
    {
        base.OnDamageArea();
        _health -= 5f;
        Debug.Log("Hero Health : " + _health);
    }
}
