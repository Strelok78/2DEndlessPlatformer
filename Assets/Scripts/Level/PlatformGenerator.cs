using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefabs[0]);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _timeToSpawn)
        {
            if(TryGetObject(out GameObject platform))
            {
                _elapsedTime = 0;

                float spawPositionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 spwnPoint = new(transform.position.x, spawPositionY, 0f);

                platform.SetActive(true);
                platform.transform.position = spwnPoint;
            }
        }
    }
}
