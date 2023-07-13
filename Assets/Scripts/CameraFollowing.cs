using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _cameraXPosGap;

    private void Update()
    {
        _camera.transform.position = new Vector3(_player.transform.position.x + _cameraXPosGap, _camera.transform.position.y, _camera.transform.position.z);
    }
}
