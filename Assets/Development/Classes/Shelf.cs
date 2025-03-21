using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct ShelfMap
{
    public Transform shelfTransform;
    public GameObject shelfObject;

    public ShelfMap(Transform shelftransform, GameObject shelfObject)
    {

        this.shelfTransform = shelftransform;
        this.shelfObject = shelfObject;
    }

}
public class Shelf : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _mesh;
    public List<ShelfMap> _productsInShelf = new();
    private void Start()
    {
        for (int i = 0; i < _mesh.transform.childCount; i++)
        {
            ShelfMap shelfMap = new ShelfMap(_mesh.transform.GetChild(i), null);
            _productsInShelf.Add(shelfMap);
        }
    }


    public void onInteractionStart()
    {

    }

    //overloaded fonk yaptýk
    public void onInteractionStart(List<GameObject> items)
    {
        List<GameObject> RemoveItems = new();

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < _productsInShelf.Count; j++)
            {
                if (_productsInShelf[j].shelfObject == null)
                {
                    items[i].transform.parent = _productsInShelf[j].shelfTransform;
                    items[i].transform.position = _productsInShelf[j].shelfTransform.position;
                    ShelfMap tempMap = new ShelfMap(_productsInShelf[j].shelfTransform, items[i]);
                    _productsInShelf[j] = tempMap;
                    // FindObjectOfType<PlayerCharachter>().RemoveProductCollection(items[i]);
                    RemoveItems.Add(items[i]);
                    break;
                }
            }
        }
        foreach (var o in RemoveItems)
        {


            FindObjectOfType<PlayerCharachter>().RemoveProductFromCollection(o.GetComponent<Sneakers>());

        }
    }
    public void onInteractionEnd()
    {

    }

    public List<GameObject> GetItemsByCount(int itemCount)
    {
        List<GameObject> collectionList = new();
        for (int i = 0; i < itemCount; i++)
        {
            for (int j = 0; j < _productsInShelf.Count; j++)
            {
                if (_productsInShelf[j].shelfObject != null)
                {
                    collectionList.Add(_productsInShelf[j].shelfObject);
                    ShelfMap tempMap = new ShelfMap(_productsInShelf[j].shelfTransform, null);
                    _productsInShelf[j] = tempMap;
                    break;
                }
            }


        }

        return collectionList;
    }

    public bool isThereAnyGameObjectInShelf()
    {
        bool result = false;

         for (int i = 0; i < _productsInShelf.Count; i++)
         {
             if (_productsInShelf[i].shelfObject != null)
             {
                
                 result = true;
                 break;
             }
           
         }

     
        return result;
    }
}



