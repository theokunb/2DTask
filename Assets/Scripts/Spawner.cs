using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _spawnTime;

    private SpawnPoint[] _points;
    private System.Random _random;
    private bool _allSpawned => _points.All(point => point.Spawned == true);

    private void Start()
    {
        _random = new System.Random();
        _points = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitSpawnTime = new WaitForSeconds(_spawnTime);

        for(int i = 0; i < _points.Length; i++)
        {
            var index = FindFreeIndexPoint();
            var spawnTransform = transform.GetChild(index);
            _points[index].Spawn(_template, spawnTransform.position, Quaternion.identity);
            
            yield return waitSpawnTime;
        }
    }

    private int FindFreeIndexPoint()
    {
        int index;
        do
        {
            index = _random.Next(0, _points.Length);
        } while(_allSpawned == false && _points[index].Spawned == true);

        return index;
    }
}
