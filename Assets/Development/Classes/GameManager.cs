using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnShelfSpawned(List<Shelf>  shelfList);
public delegate void OnCashierSpawned(List<Cashier> cashierList);
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Shelf> spawnedShelves = new();
    public List<Cashier> spawnedCashiers = new();

    public OnShelfSpawned onShelfSpawned;
    public OnCashierSpawned onCashierSpawned;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void OnSpawnShelf(Shelf newShelf)
    {
        spawnedShelves.Add(newShelf);
        onShelfSpawned?.Invoke(spawnedShelves);
    }
    public void OnSpawnCashiers(Cashier newCashier)
    {
        spawnedCashiers.Add(newCashier);
        onCashierSpawned?.Invoke(spawnedCashiers);

    }
    public void OnSpawnedArea(GameObject newArea)
    {
        if (newArea.GetComponent<Shelf>())
        {
            OnSpawnShelf(newArea.GetComponent<Shelf>());
        }
        else if (newArea.GetComponent<Cashier>())
        {
            OnSpawnCashiers(newArea.GetComponent<Cashier>());
        }
    }
}
