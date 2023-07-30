using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("");
    }

    public Coin(Vector2 position)
    {
        transform.position = position;
    }
}
