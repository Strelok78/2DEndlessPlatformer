using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDrawer : MonoBehaviour //надо упростить или разбить на 2 доп скрипта (water и ground)
{
    private const int _maxPositionY = 6;
    private const int _minPositionY = 0;

    [SerializeField] private List<Tile> _groundTiles;
    [SerializeField] private Tile _waterTile;
    [SerializeField] private Tilemap _tilemapGround;
    [SerializeField] private Tilemap _tilemapWater;
    [SerializeField] private GameObject _generator;
    [SerializeField] private GameObject _destroyer;
    [SerializeField] private int _maxEmptySpace;
    [SerializeField] private int _maxPlatformLength;
    [SerializeField] private int _maxStepByY;

    private System.Random _random;
    private Queue<Vector3Int> _groundPositionContainer;
    private int _furtherPositionX;
    private int _currentPositionY;

    private void Start()
    {
        _random = new System.Random();
        _groundPositionContainer = new Queue<Vector3Int>();
        _furtherPositionX = (int)_generator.transform.position.x;
        _currentPositionY = _minPositionY;
    }

    private void Update()
    {
        if (_furtherPositionX < (int)_generator.transform.position.x)
            DrawLevel();

        if (_groundPositionContainer.Count > 0) //переделать удаление
            RemoveTile();
    }

    private void DrawLevel()
    {
        ShiftVerticalPosition();
        DrawWater(_random.Next(1, _maxEmptySpace));
        DrawPlatform(_random.Next(1, _maxPlatformLength));
    }

    private void DrawPlatform(int platformLength)
    {
        if (_currentPositionY > 0)
        {
            platformLength = Mathf.Max(platformLength, 2);

            DrawWater(platformLength);
            _furtherPositionX -= (platformLength);

            DrawTile(1, _groundTiles[0]);
            DrawTile(platformLength - 2, _groundTiles[1]);
            DrawTile(1, _groundTiles[2]);
        }
        else
        {
            DrawTile(platformLength, _groundTiles[1]);
        }
    }

    private void DrawWater(int spaceLength)
    {
        DrawTile(spaceLength, _waterTile, false);
    }

    private void DrawTile(int tilesCount, Tile tile, bool isGround = true)
    {
        int positionY = isGround ? _currentPositionY : _minPositionY;

        for (int i = 0; i < tilesCount; i++)
        {
            Vector3Int tileLocation = new(_furtherPositionX++, positionY);

            if (isGround)
            {
                _tilemapGround.SetTile(tileLocation, tile);

                if (tileLocation.y != 0)
                    _groundPositionContainer.Enqueue(tileLocation);
            }
            else
            {
                _tilemapWater.SetTile(tileLocation, tile);
            }
        }
    }

    private void ShiftVerticalPosition()
    {
        int stepValue = _random.Next(_maxStepByY + 1);
        int randomizer = _random.Next(2);

        switch (_currentPositionY)
        {
            case _minPositionY:
                _currentPositionY += stepValue;
                break;

            case _maxPositionY:
                _currentPositionY -= stepValue;
                break;

            default:
                _currentPositionY += randomizer == 0 ? stepValue : -stepValue;
                _currentPositionY = Mathf.Clamp(_currentPositionY, _minPositionY, _maxPositionY);
                break;
        }
    }

    private void RemoveTile()
    {
        Vector3Int location = new((int)_destroyer.transform.position.x, _minPositionY);

        _tilemapGround.SetTile(location, null);
        _tilemapWater.SetTile(location, null);

        if (_groundPositionContainer.Peek().x <= (int)_destroyer.transform.position.x)
        {
            _tilemapGround.SetTile(_groundPositionContainer.Dequeue(), null);
        }
    }
}