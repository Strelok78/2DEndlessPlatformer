using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerScore : MonoBehaviour
{
    private int _coins;

    public event UnityAction<int> OnScoreChanged;

    private void Start()
    {
        _coins = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            IncreaseCoins(coin.CoinValue);
            Destroy(collision.gameObject);
        }
    }

    private void IncreaseCoins(int coinValue)
    {
        _coins += coinValue;
        OnScoreChanged?.Invoke(_coins);
    }

    private void ResetCoins() // для рестарта игры
    {
        _coins = 0;
    }
}
