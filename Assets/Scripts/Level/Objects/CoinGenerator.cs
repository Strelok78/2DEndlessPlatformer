using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void OnEnable()
    {
        //_tileDrawer.OnTileCreated += GenerateCoint;
    }

    private void OnDisable()
    {
        //_tileDrawer.OnTileCreated -= GenerateCoint;
    }

    private void GenerateCoin(Vector2 tilePosition, int tileLength)
    {
        System.Random random = new System.Random();
        int coinHoritontalPosition = random.Next(tileLength) + 1;
        int coinVerticalPosition = random.Next((int)tilePosition.y, 10);
        Vector2 coinPosition = new Vector2(tilePosition.x + coinHoritontalPosition, coinVerticalPosition); //контролировать позицию - пока позиция
                                                                                                           //не передается (возможно менять позицию генератора?? нет)
        Instantiate(coinPrefab);
    }
}