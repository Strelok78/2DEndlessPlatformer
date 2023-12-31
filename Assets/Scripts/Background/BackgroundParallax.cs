using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float[] _speed;
    [SerializeField] private Camera _camera;

    private RawImage[] _backgroundImages;
    private float[] _imagePositionX;
    private float _lastCameraPosition;

    private void Start()
    {
        _lastCameraPosition = _camera.transform.position.x;
        _backgroundImages = GetComponentsInChildren<RawImage>();
        FillPosiotionsX();
    }

    private void FixedUpdate()
    {
        SimulateParallax(GetDirection());
    }

    public void SimulateParallax(float direction)
    {
        for (int i = 0; i < _backgroundImages.Length; i++)
        {
            _imagePositionX[i] += _speed[i] * direction * Time.deltaTime;

            if (_imagePositionX[i] > 1)
                _imagePositionX[i] = 0;

            _backgroundImages[i].uvRect = new Rect(_imagePositionX[i], 0, _backgroundImages[i].uvRect.width, _backgroundImages[i].uvRect.height);
        }
    }

    private float GetDirection()
    {
        float currentCameraPositionX = _camera.transform.position.x;

        float direction = _lastCameraPosition > currentCameraPositionX ? -1f : _lastCameraPosition < currentCameraPositionX ? 1f : 0f;
        _lastCameraPosition = currentCameraPositionX;

        return direction;
    }

    private void FillPosiotionsX()
    {
        _imagePositionX = new float[_backgroundImages.Length];

        for (int i = 0; i < _imagePositionX.Length; i++)
        {
            _imagePositionX[i] = _backgroundImages[i].uvRect.x;
        }
    }
}