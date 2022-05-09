using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    [SerializeField] private GameObject _prefabStar;

    private float _randX;
    private Vector2 _whereToSpawn;

    [SerializeField] private float _spawnRate = 5f;
    private float _nextSpawn = 0.0f;

    private void Update()
    {
        if(Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randX = Random.Range(-1f, 1f);
            _whereToSpawn = new Vector2(_randX, transform.position.y);
            Instantiate(_prefabStar, _whereToSpawn, Quaternion.identity);
        }
    }
}
