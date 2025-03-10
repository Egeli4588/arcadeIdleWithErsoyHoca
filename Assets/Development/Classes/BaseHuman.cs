using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class BaseHuman : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _health=100f;


    private void Start()
    {
        InputManager.Instance.onMouseEventTriggered += Move;
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        InputManager.Instance.onMouseEventTriggered -= Move;    
    }


   protected virtual void Move(Vector3 moveDirecton)
    {
        Vector3 newDir = new Vector3(moveDirecton.x * _moveSpeed, 0f, moveDirecton.y * _moveSpeed);
        _rigidbody.velocity = newDir*_moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageArea"))
        {
         OnDamageArea();
        }

        if (other.CompareTag("BoostArea"))
        {
            OnBoostArea();
        }
    }


    protected virtual void OnDamageArea() 
    {
        Debug.Log("Damage Area");
    }

    protected virtual void OnBoostArea()
    {
        Debug.Log("Boost Area");
    }


}
