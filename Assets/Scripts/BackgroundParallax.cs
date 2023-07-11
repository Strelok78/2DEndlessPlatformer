using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float[] _speed;
 
    private RawImage[] _backgroundImages;
    private float[] _imagePositionX;

    private void Start()
    {
        _backgroundImages = GetComponentsInChildren<RawImage>();
        FillXPosiotions();
    }

    private void Update()
    {
        for (int i = 0; i < _backgroundImages.Length; i++)
        {
            _imagePositionX[i] += _speed[i] * Time.deltaTime;

            if (_imagePositionX[i] > 1)
                _imagePositionX[i] = 0;

            _backgroundImages[i].uvRect = new Rect(_imagePositionX[i], 0, _backgroundImages[i].uvRect.width, _backgroundImages[i].uvRect.height);
        }
    }

    private void FillXPosiotions()
    {
        _imagePositionX = new float[_backgroundImages.Length];

        for (int i = 0; i < _imagePositionX.Length; i++)
        {
            _imagePositionX[i] = _backgroundImages[i].uvRect.x;
        }
    }
}
//привязать перемещение игрока