using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//[RequireComponent(typeof(Tilemap))]
//[RequireComponent(typeof(TilemapRenderer))]
public class TilemapGroundGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private TilemapRenderer _tilemapRenderer;
    [SerializeField] private Tile _tile;

    private Vector3Int _paintorPosiotion;

    private void Update()
    {
        for (int i = -7; i < 50; i++)
        {
            _paintorPosiotion = new Vector3Int(i, -5, 0);

            _tilemap.SetTile(_paintorPosiotion, _tile);
            
        }
    }
}
