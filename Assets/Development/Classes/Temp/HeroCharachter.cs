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
        _humanAttributes._health -= 5f;
        Debug.Log("Hero Health : " + _humanAttributes._health);
    }

    protected override void OnBoostArea()
    {
        base.OnBoostArea();
        _humanAttributes._moveSpeed += 5f;
        Debug.Log("Hero Speed : " + _humanAttributes._moveSpeed);
        OnHeroTrigger();
    }

    public void OnHeroTrigger() 
    {
        Debug.Log("Hero Trigger");
    }
}
