using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct productMap
{
    public Transform Key;
    public GameObject Value;

    public productMap(Transform t, GameObject g)
    {
        Key = t;
        Value = g;
    }

}
public class CollactableArea : BaseInteractionArea
{

    [SerializeField] protected GameObject _spawnProduct;
    [SerializeField] protected List<Transform> productTransforms;
    [SerializeField] private float _delayTime;
    // private int _index = 0;

    //  [SerializeField] private Dictionary<Transform, GameObject> _productsDictionary= new ();  bunu structrdan sonra iptal ediyorum
    [SerializeField] private List<productMap> _productsDictionary = new();

    private PlayerCharachter _playerCharachter;
    private void Awake()
    {
        _playerCharachter = FindObjectOfType<PlayerCharachter>();

        _playerCharachter.onItemCollected += UpdateProductDictionary;

    }
    private void OnDisable()
    {
        _playerCharachter.onItemCollected += UpdateProductDictionary;
    }


    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < transform.childCount; i++)
        {
            productMap map = new productMap(transform.GetChild(i), null);


            _productsDictionary.Add(map);

            // _productsDictionary.Add(transform.GetChild(i),null);
            // productTransforms.Add(transform.GetChild(i));
        }




        StartCoroutine("spawnProduct");
    }

   

    public override void onInteractionStart()
    {
        base.onInteractionStart();
    }

    private IEnumerator spawnProduct()
    {
        /*  Instantiate(_spawnProduct, productTransforms[_index].position, Quaternion.identity);
          _index++;
          if (_index < productTransforms.Count)
          {
              yield return new WaitForSeconds(2f);
              StartCoroutine("spawnProduct");

          }
          else {

              Debug.Log("Ürünler üretildi");

          }

          */
        //---   ürünleri dictionary ile doldurmak Foreach ile  bu çalýþmýyor diðer forla üzerinden geçtik 

        /*   foreach (var o in _productsDictionary)
           {

               if (o.Value == null)
               {
                   GameObject go = Instantiate(_spawnProduct, o.Key.position, Quaternion.identity);

                   productMap temp = new productMap(o.Key, go);
                   //   _productsDictionary[o.Key] = go;
                   break;
               }
           }
        */   //----- burda oluþturduðumuz tampon dictionary üzerinden iþlemleri gerçekleþtirdik bu da farklý bir sistem
        for (int i = 0; i < _productsDictionary.Count; i++)
        {
            if (_productsDictionary[i].Value == null)
            {
                GameObject go = Instantiate(_spawnProduct, _productsDictionary[i].Key.position, Quaternion.identity);
          

                go.transform.parent = _productsDictionary[i].Key.transform;


                productMap temp = new productMap(_productsDictionary[i].Key, go);
                //   _productsDictionary[o.Key] = go;

                _productsDictionary[i] = temp;
                break;
            }

        }

        yield return new WaitForSeconds(_delayTime);
        StartCoroutine("spawnProduct");

    }

    public void UpdateProductDictionary(Sneakers item, List<Sneakers> itemlist)
    {


        for (int i = 0; i < _productsDictionary.Count; i++)
        {
            if (_productsDictionary[i].Value == item.gameObject)
            {

                _productsDictionary[i] = new productMap(_productsDictionary[i].Key, null);
            }
        }
    }

}
