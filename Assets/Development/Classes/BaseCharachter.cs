using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseCharachter : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    [SerializeField] protected  float _moveSpeed;


    protected virtual void Awake() 
    {
      _rigidbody = GetComponent<Rigidbody>();   
    }

    protected void Start()
    {
        InputManager.Instance.onMouseEventTriggered += Move;
        InputManager.Instance.onMouseEventTriggered += RotateCharacter;
    }
    protected virtual void onEnable() 
    {

       
    
    }

    protected virtual void onDisable()
    {
        InputManager.Instance.onMouseEventTriggered -= Move;
        InputManager.Instance.onMouseEventTriggered -= RotateCharacter;

    }
    protected virtual void Move(Vector3 moveDir)
    {
        Vector3 newDir = new Vector3(moveDir.x * _moveSpeed, 0f, moveDir.y * _moveSpeed);
        _rigidbody.velocity = newDir ;

    }

    protected virtual void RotateCharacter(Vector3 moveDir) 

    {
        Vector3 newDir = new Vector3(moveDir.x * _moveSpeed, 0f, moveDir.y * _moveSpeed);

        Quaternion newRot= Quaternion.LookRotation(newDir,transform.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,newRot,250*Time.deltaTime);
    
    }


    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null) 
        {
            interactable.onInteractionStart();
        
        }
    }
}
