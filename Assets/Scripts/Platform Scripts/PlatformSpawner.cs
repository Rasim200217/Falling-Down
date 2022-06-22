using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject PlatformPrefab;
    public GameObject SpikePlatformPrefab;
    public GameObject[] MovingPlatforms;
    public GameObject BreakablePlatform;

    public float PlatformSpawnTimer = 1.2f;
    private float _currentPlatformSpawnTimer;

    private int _platformSpawnCount;

    public float MinX = -2f, MaxX = 2f;

    void Start()
    {
        _currentPlatformSpawnTimer = PlatformSpawnTimer;
    }

    void Update()
    {
        SpawnPlatform();
    }

    void SpawnPlatform()
    {
        _currentPlatformSpawnTimer += Time.deltaTime;
        
        if(_currentPlatformSpawnTimer >= PlatformSpawnTimer)
        {
            _platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(MinX, MaxX);

            GameObject newPlatform = null;

            if(_platformSpawnCount < 2)
            {
                newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);
            }else if(_platformSpawnCount == 2)
            {
                if(Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);
                }else
                {
                    newPlatform = Instantiate(MovingPlatforms[Random.Range(0, MovingPlatforms.Length)], temp, Quaternion.identity);

                }
            }else if(_platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(SpikePlatformPrefab, temp, Quaternion.identity);

                }
            }
            else if (_platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(PlatformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(BreakablePlatform, temp, Quaternion.identity);

                }
                _platformSpawnCount = 0;
            }
           
            if(newPlatform)
                newPlatform.transform.parent = transform;

            _currentPlatformSpawnTimer = 0f;
        }
    }
}
