using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]// strucera editörde görebilmek için
public struct HumanAttributes
{
    public float _moveSpeed;
    public float _health;

}
public abstract class BaseHuman : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected HumanAttributes _humanAttributes;
    [SerializeField] protected List<HumanAttributes> _listAttributes;
    [SerializeField] protected int _age;

    protected BaseHuman() //yapýcý fonksiyon tanýmlamýþ oluyorum
    {
    
    }
    protected BaseHuman(int ageValue) // deðer alan yapýcý fonksiyon tanýmlamýþ oluyorum 
    {
      
        _age = ageValue;
    }
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
        Vector3 newDir = new Vector3(moveDirecton.x * _humanAttributes._moveSpeed, 0f, moveDirecton.y * _humanAttributes._moveSpeed);
        //_rigidbody.velocity = newDir * _humanAttributes._moveSpeed;

        transform.position += newDir* _humanAttributes._moveSpeed*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        /* if (other.CompareTag("DamageArea"))
         {
          OnDamageArea();
         }

         if (other.CompareTag("BoostArea"))
         {
             OnBoostArea();
         }
        */
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
