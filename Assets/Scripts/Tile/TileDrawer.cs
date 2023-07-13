using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//[RequireComponent(typeof(Tilemap))]
//[RequireComponent(typeof(TilemapRenderer))]
public class TileDrawer : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _tile;

    private void DrawPlatform(int newPositionX)
    {
        Vector3Int paintorPosition = new Vector3Int(newPositionX, 0, 0);
        _tilemap.SetTile(paintorPosition, _tile);
    }

    private void RemovePlatform(int removingPositionX)
    {
        Vector3Int paintorPosition = new Vector3Int(removingPositionX, 0, 0);
        _tilemap.SetTile(paintorPosition, null);
    }
}
