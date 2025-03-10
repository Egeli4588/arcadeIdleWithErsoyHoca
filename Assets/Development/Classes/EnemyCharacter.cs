using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseHuman
{
    protected override void Move(Vector3 moveDirecton)
    {
        base.Move(moveDirecton);


        //  e�er istersek burdan override ederek bunlar� de�i�tirebiliriz
        /*   Vector3 newDir = new Vector3(moveDirecton.x * _moveSpeed, moveDirecton.y * _moveSpeed,0f);
           _rigidbody.velocity = newDir * _moveSpeed; */
    }

    protected override void OnDamageArea()
    {
        base.OnDamageArea();
        _health -= 25f;
        Debug.Log("Enemy Health : " + _health);
    }

    protected override void OnBoostArea()
    {
        base.OnBoostArea();
    }
}
