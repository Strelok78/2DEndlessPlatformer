using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour //maybe add some spaces between platforms later...
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _tile;
    [SerializeField] private GameObject _generator;
    [SerializeField] private GameObject _destroyer; //мб стоит сделать отдельными скриптами с ивентами, чтобы сделать доступным удаление не только тайлов, но и врагов и прочие объекты

    private int _farestPositionX;

    private void Start()
    {
        _farestPositionX = (int)_generator.transform.position.x;
    }

    private void Update()
    {
        if((int)_generator.transform.position.x > _farestPositionX)
        {
            EditPlatform();
            _farestPositionX = (int)transform.position.x;
        }
    }

    private void EditPlatform()
    {
        int newPlatformPositionX = (int)_generator.transform.position.x;
        int removingPlatformPositionX = (int)_destroyer.transform.position.x;

        Vector3Int paintorPosition = new Vector3Int(newPlatformPositionX, 0, 0);
        Vector3Int destroyerPosition = new Vector3Int(removingPlatformPositionX, 0, 0);

        _tilemap.SetTile(paintorPosition, _tile);
        _tilemap.SetTile(destroyerPosition, null);
    }
}
