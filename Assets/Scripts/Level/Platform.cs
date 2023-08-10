using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float _currentRigthX { get; private set; }
    public float _currentRigthY { get; private set; }

    private void Update()
    {
        _currentRigthX = ReceivePlatformEndX();
        _currentRigthY = transform.position.y;
    }

    private float ReceivePlatformEndX()
    {
        float resultPosition = 0f;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (resultPosition < transform.GetChild(i).position.x)
                resultPosition = transform.GetChild(i).position.x;
        }

        return transform.position.x + resultPosition;
    }
}