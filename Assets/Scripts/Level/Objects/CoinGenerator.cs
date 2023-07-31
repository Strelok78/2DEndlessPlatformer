using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private TileDrawer _tileDrawer;
    [SerializeField] private Transform _destroyer;
    [SerializeField] private int _randomRate;

    private Queue<GameObject> _coins;

    private void Start()
    {
        _coins = new Queue<GameObject>();
    }

    private void OnEnable()
    {
        _tileDrawer.OnTileCreated += GenerateCoin;
    }

    private void OnDisable()
    {
        _tileDrawer.OnTileCreated -= GenerateCoin;
    }

    private void GenerateCoin(Vector3Int tilePosition, int tileLength) //мб добавить ранддомайзер который решает создавать
                                                                       //над тайлом моентку или нет, чтобы уменьшить их кол-во
    {
        System.Random random = new System.Random();
        int randomizer = random.Next(_randomRate);

        if (randomizer == 0)
        {
            int coinVerticalPosition = tilePosition.y - 3;
            Vector3 coinPosition = new(tilePosition.x - 4.5f, coinVerticalPosition);

            GameObject newCoin = Instantiate(coinPrefab);
            newCoin.transform.position = coinPosition;

            _coins.Enqueue(newCoin);
        }

        DestroyCoin();
    }

    private void DestroyCoin()
    {
        if(_coins.TryPeek(out GameObject coin) && coin.transform.position.x <= _destroyer.position.x)
        {
            Destroy(_coins.Dequeue());
        }
    }
}