using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerScore : MonoBehaviour
{
    private int _coins;
    private CapsuleCollider2D _capsuleCollider;

    private void Start()
    {
        _coins = 0;
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent(out Coin coin))
        //    IncreaseCoins();
    }

    private void IncreaseCoins()
    {
        _coins++;
    }

    private void ResetCoins()
    {
        _coins = 0;
    }
}
