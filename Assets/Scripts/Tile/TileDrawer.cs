using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDrawer : MonoBehaviour
{
    private const int _maxPositionY = 0;
    private const int _minPositionY = 6;

    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _groundTileMiddle;
    [SerializeField] private Tile _groundTileStart;
    [SerializeField] private Tile _groundTileEnd;
    [SerializeField] private Tile _waterTile;
    [SerializeField] private Transform _tileGenerator;
    //[SerializeField] private GameObject _tileDestroyer; //no need in it if destroying by count of tiles in queue
    [SerializeField] private int _maxStepByY;
    [SerializeField] private int _maxPlatformsDrawn;
    [SerializeField] private int _maxPlatformLength;
    [SerializeField] private int _maxDistanceBetweenPlatforms;

    private int _currentPositionY;
    private int _furtherPositionX;
    private System.Random _random;
    private Queue<Vector3Int> _tilesContainer;

    private void Start()
    {
        _random = new System.Random();
        _furtherPositionX = (int)_tileGenerator.position.x;
        _currentPositionY = 0;
    }

    private void Update()
    {
        if ((int)_tileGenerator.transform.position.x > _furtherPositionX)
            DrawPlatform();

        if (_tilesContainer.Count > _maxPlatformsDrawn)
            RemovePlatform();
    }

    //method making spaces (filled with water) - water tile ratio
    //and method making platforms they use all 3 types of ground tiles
    //lower position uses only middle ground tile because of better look with water tiles
    //*If we create platform require min platform length parameter (to make start and end tile drawn)
    //+ we create step by stp we need to move to next X position that will be  >= x + 3
    private void DrawPlatform()
    {
        int currentGeneratorPositionX = (int)_tileGenerator.position.x;

        ShiftVerticalPosition();
        Vector3Int groundPainterPosition = new(currentGeneratorPositionX, _currentPositionY, 0);
        Vector3Int waterPainterPosition = new(groundPainterPosition.x, _minPositionY, 0);

        if (_currentPositionY > 0)
        {
            _tilemap.SetTile(waterPainterPosition, _waterTile);
            _tilemap.SetTile(groundPainterPosition, _groundTileMiddle);
        }
        else
        {
            _tilemap.SetTile(groundPainterPosition, _groundTileMiddle);
        }

        _tilesContainer.Enqueue(groundPainterPosition);
        _furtherPositionX = currentGeneratorPositionX;
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
                _currentPositionY = _currentPositionY < _minPositionY ? _minPositionY : _currentPositionY > _maxPositionY ? _maxPositionY : _currentPositionY;
                break;
        }
    }

    private void RemovePlatform()
    {
        _tilemap.SetTile(_tilesContainer.Dequeue(), null);
    }
}