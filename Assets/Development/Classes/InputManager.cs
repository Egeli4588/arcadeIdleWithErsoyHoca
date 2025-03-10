using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnMouseEventTriggered(Vector3 direction);// event tanýmladýk
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private Vector3 beginPos;
    private Vector3 currentPos;
    private Vector3 deltaPos;



    public OnMouseEventTriggered onMouseEventTriggered;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(this);
        }
       Instance = this;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            beginPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            deltaPos = currentPos - beginPos;
            deltaPos.Normalize();// herhangi bir vektörü birim vektöre dönüþtürmüþ oluyoruz
            onMouseEventTriggered?.Invoke(deltaPos);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            onMouseEventTriggered?.Invoke(Vector3.zero);
        }
    }
}
