using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayermMovement : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Move(Vector2.left);
        if (Input.GetKey(KeyCode.D))
            Move(Vector2.right);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
