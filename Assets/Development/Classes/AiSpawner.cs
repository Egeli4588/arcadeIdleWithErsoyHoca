using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnTransforms;
    [SerializeField] private GameObject _aiPrefab;
    [SerializeField] private int _maxCapacity;
    private int _currentCapacity;
    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        int randIndx = Random.Range(0, _spawnTransforms.Count - 1);
        GameObject ai = Instantiate(_aiPrefab, _spawnTransforms[randIndx].position, Quaternion.identity);

        _currentCapacity++;
        int randSeconds = Random.Range(1, 3);
        yield return new WaitForSeconds(randSeconds);

        if (_currentCapacity < _maxCapacity)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    public void DecreaseCapacity()
    {
        _currentCapacity--;

        StartCoroutine(SpawnCoroutine());

    }
}
