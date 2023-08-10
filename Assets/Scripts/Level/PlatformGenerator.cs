using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private Platform[] _prefabs;
    [SerializeField] private float _maxStepX;
    [SerializeField] private float _minStepX;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private float _currentFarthestX;
    private float _elapsedTime = 0;

    private void Start()
    {
        IncludeStartObjects(gameObject);
        Initialize(_prefabs[(int)Random.Range(0, _prefabs.Length)].gameObject);
    }

    private void Update()
    {
        Vector2 spawnPoint = new(ShiftByX(), ShiftByY(1f/*данные из префаба*/));

        //_elapsedTime += Time.deltaTime;

        //if(_elapsedTime > _timeToSpawn)
        //{
        //    if(TryGetObject(out GameObject platform))
        //    {
        //        _elapsedTime = 0;

        //        float spawPositionY = Random.Range(_minPositionY, _maxPositionY);
        //        Vector3 spwnPoint = new(transform.position.x, spawPositionY, 0f);

        //        platform.SetActive(true);
        //        platform.transform.position = spwnPoint;
        //    }
        //}
    }

    private float ShiftByX()
    {
        float shiftDistance = Random.Range(_minStepX, _maxStepX);
        return _currentFarthestX + shiftDistance; //обновлять _currentFartherPosition
    }

    private float ShiftByY(float currentY)
    {
        return currentY + (Mathf.Clamp(Random.Range(0, 1.5f), _minPositionY, _maxPositionY));
    }

    private void UpdateFartherX()
    {
        //искать перебирая все, либо передавать сюда при создании нового экземпляр префаба или просто отправлять сюда прямо или прямо там же обновлять самую дальнюю позицию Х 
    }
}