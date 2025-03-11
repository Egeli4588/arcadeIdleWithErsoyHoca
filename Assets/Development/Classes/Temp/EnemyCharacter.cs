using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseHuman,IDamageArea
{
    protected override void Move(Vector3 moveDirecton)
    {
        base.Move(moveDirecton);


        //  eðer istersek burdan override ederek bunlarý deðiþtirebiliriz
        /*   Vector3 newDir = new Vector3(moveDirecton.x * _moveSpeed, moveDirecton.y * _moveSpeed,0f);
           _rigidbody.velocity = newDir * _moveSpeed; */
    }

    protected override void OnDamageArea()
    {
        base.OnDamageArea();
        _humanAttributes._health -= 25f;
        Debug.Log("Enemy Health : " + _humanAttributes._health);
    }

    protected override void OnBoostArea()
    {
        base.OnBoostArea();
        _humanAttributes._moveSpeed += 2f;
        Debug.Log("Enemy Speed : " + _humanAttributes._moveSpeed);
        OnEnemyTrigger();
    }

    public void OnEnemyTrigger() 
    {
        Debug.Log("Enemy Trigger");
    }

    public void OnEnteredDamageArea()
    {
        Debug.Log("interface çalýþtý");
    }
}
