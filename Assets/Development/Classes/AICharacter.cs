using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Squence
{
    IDLE,
    SHOPPING,
    PAYMENT

}
public class AICharacter : MonoBehaviour
{
    [SerializeField] private List<Transform> _moveTransforms;
    [SerializeField] private float speed;
    private List<Shelf> _shelves;
    private List<Cashier> _cashiers;

    private List<GameObject> _shoppingItemsList;

    private Coroutine _actionCoroutine;

    private Squence _squenceEnum;
    private void Awake()
    {

        _squenceEnum = Squence.IDLE;

    }

    private void Start()
    {
        GameManager.instance.onShelfSpawned += OnShelfSpawned;
        GameManager.instance.onCashierSpawned += OnCashierSpawned;
        SetSquenceEnum(Squence.IDLE);
    }

    private void OnDisable()
    {
        GameManager.instance.onShelfSpawned -= OnShelfSpawned;
        GameManager.instance.onCashierSpawned -= OnCashierSpawned;
    }

    private void OnShelfSpawned(List<Shelf> shelves)
    {
        _shelves = shelves;
        SetSquenceEnum(Squence.SHOPPING);

    }
    private void OnCashierSpawned(List<Cashier> cashiers)
    {
        _cashiers = cashiers;
    }


    public void SetSquenceEnum(Squence newState)
    {
        _squenceEnum = newState;
        if (_actionCoroutine != null)
        {
            StopCoroutine(_actionCoroutine);
        }
        switch (_squenceEnum)
        {
            case Squence.IDLE:
                _actionCoroutine = StartCoroutine(IdleCoroutine());
                break;
            case Squence.SHOPPING:
                _actionCoroutine = StartCoroutine(ShoppingCoroutine());
                break;
            case Squence.PAYMENT:
                _actionCoroutine = StartCoroutine(PaymentCoroutine());
                break;
            default:
                break;
        }
    }

    private bool IsThereAnyCashier()
    {
        //  ternary
        return _cashiers != null;


    }

  
    private IEnumerator IdleCoroutine()
    {
        int ranIdx = UnityEngine.Random.Range(0, _moveTransforms.Count - 1);
        while (Vector3.Distance(transform.position, _moveTransforms[ranIdx].position) > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveTransforms[ranIdx].position, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1);


        _actionCoroutine = StartCoroutine(IdleCoroutine());


    }
    private IEnumerator ShoppingCoroutine()
    {
        while (Vector3.Distance(transform.position, _shelves[0].transform.position) > 2.5f)
        {
            transform.position =
                        Vector3.MoveTowards(transform.position, _shelves[0].transform.position, speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
        //..

        while (!FindObjectOfType<Shelf>().isThereAnyGameObjectInShelf())
        {
            yield return new WaitForSeconds(1);
        }
        int randItemCount = UnityEngine.Random.Range(1, 5);
        AddProductsToShoppingCard(randItemCount);
        yield return new WaitForSeconds(2f);
        while (!IsThereAnyCashier())
        {
            yield return new WaitForSeconds(1f);
        }

        SetSquenceEnum(Squence.PAYMENT);


    }
    private IEnumerator PaymentCoroutine()
    {
        while (Vector3.Distance(transform.position, _cashiers[0].transform.position) > 2.5f)
        {
            transform.position =
                        Vector3.MoveTowards(transform.position, _cashiers[0].transform.position, speed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

    public void AddProductsToShoppingCard(int itemCount)
    {
        _shoppingItemsList = FindObjectOfType<Shelf>().GetItemsByCount(itemCount);
        if (_shoppingItemsList.Count > 0)
        {
            foreach (GameObject item in _shoppingItemsList)
            {


                item.transform.position = transform.position + (transform.up * (2 + _shoppingItemsList.IndexOf(item)));
                item.transform.parent = transform;
            }

        }
    }
}
