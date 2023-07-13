using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//[RequireComponent(typeof(Tilemap))]
//[RequireComponent(typeof(TilemapRenderer))]
public class TilemapGroundGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _tileStart;
    [SerializeField] private Tile _tileMiddle;
    [SerializeField] private Tile _tileEnd;

    private void Start()
    {
        GeneratePlatformPosition();
    }

    private void Update()
    {

    }

    private void DrawPlatform(Vector3Int newPosition, int platformLength)
    {
        System.Random _random = new System.Random();
        Vector3Int _paintorStartPosiotion = newPosition;
        Vector3Int _paintorMiddlePosition = newPosition + new Vector3Int(1, 0, 0); ;
        Vector3Int _paintorEndPosiotion = newPosition + new Vector3Int(platformLength - 1, 0, 0);

        _tilemap.SetTile(_paintorStartPosiotion, _tileStart);

        for (int i = 0; i < platformLength - 2; i++, _paintorMiddlePosition.x++)
        {
            _tilemap.SetTile(_paintorMiddlePosition, _tileMiddle);
        }

        _tilemap.SetTile(_paintorEndPosiotion, _tileEnd);
        //_tilemap.SetTile(_paintorStartPosiotion, null); //удаление тайла
    }

    private void GeneratePlatformPosition()
    {
        System.Random _random = new System.Random();
        int maxPlatformLength = 5;
        int minPlatformLength =3 ;
        int maxHeight = 9;
        int generetionLength = 14 * 2;
        int maxFreeSpace = 2;
        int step = 1;
        Vector3Int drawingFirstStartPosition = new Vector3Int(-7, -5, 0);
        Vector3Int drawingPosition = drawingFirstStartPosition;
        int lastMaxXPosition = 15;

        while (drawingPosition.x < lastMaxXPosition)
        {
            lastMaxXPosition = (int)transform.position.x;
            int platformLength = _random.Next(minPlatformLength, maxPlatformLength);

            DrawPlatform(drawingPosition, platformLength);

            drawingPosition.x += platformLength;
        }
    }
}
