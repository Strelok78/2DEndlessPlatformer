using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/*
 * ������� �� �����)) 
 * ��������� ������� ������
 * ���� ������ �������� ������ ��� � < ������������ �������
 * �������� ���� � ������ ������, ���� ���� ����� ���� 0
 * � ����� ������� ��������� �������, ��� ������ � ���� ��������� ����������� �������� �������� ������, 
 * ������ ��� ����������� ����� ���������� ����� � �������� 3 ������� (� ������ ����� � 2 ��������� � ��������)
 * � ���� �������� � ���, ����� �������� �������, �� ��� ���� �� ���������� �����-��, � ����������� ����
 * + ���� ��������� ���� �� �� ����� �������� � ������� ������� ���� ������ ���� ����� ���������
 */


//[RequireComponent(typeof(Tilemap))]
//[RequireComponent(typeof(TilemapRenderer))]
//public class TilemapGroundGenerator : MonoBehaviour
//{
//    [SerializeField] private Tilemap _tilemap;
//    [SerializeField] private Tile _tileStart;
//    [SerializeField] private Tile _tileMiddle;
//    [SerializeField] private Tile _tileEnd;

//    private System.Random _random = new System.Random();
//    private int _maxPlatformLength = 5; //�������� ����� ����� ��������� �� �� �������
//    private int _minPlatformLength = 3;
//    private int _maxFreeSpaceLength = 3;
//    private int _minFreeSpaceLength = 1;
//    private int _maxHeight = 9;
//    private int _minHeight = 0;
//    private int _paintorStartPositionX = 0;
//    private int lastMaxXPosition;

//    private void Start()
//    {
//        lastMaxXPosition = (int)transform.position.x;
//    }

//    private void DrawPlatform(Vector3Int paintorStartPosition, int platformLength)
//    {
//        Vector3Int paintorMiddlePosition = paintorStartPosition + new Vector3Int(1, 0, 0); ;
//        Vector3Int paintorEndPosiotion = paintorStartPosition + new Vector3Int(platformLength - 1, 0, 0);

//        _tilemap.SetTile(paintorStartPosition, _tileStart);

//        for (int i = 0; i < platformLength - 2; i++, paintorMiddlePosition.x++)
//        {
//            _tilemap.SetTile(paintorMiddlePosition, _tileMiddle);
//        }

//        _tilemap.SetTile(paintorEndPosiotion, _tileEnd);
//    }

//    private void GeneratePlatformPosition(/* ���������� ������� � ������� �������� �������� (int)transform.position.x, 
//                                           * ����� ������� ����� ������ �������� ���������� ������ (��� ��������� ������ �� �����
//                                           * ������������ drawingPositionX � lastMaxXPosition ??*/)
//    {
//        while (_paintorStartPositionX < lastMaxXPosition) //�������� ������ ����� � �������� �� ������� ��������� ��������� ������ �� �  ??
//        {
//            lastMaxXPosition = (int)transform.position.x; //����� ������� �� � �������� ���� ��� �� ��������� � do while ??
//            int platformLength = _random.Next(_minPlatformLength, _maxPlatformLength);

//            DrawPlatform(new Vector3Int(_paintorStartPositionX, 0 ,0), platformLength);

//            _paintorStartPositionX += platformLength;
//        }
//    }

//    private void DrawLevel()
//    {
//        DrawPlatform(GeneratePlatformPosition());
//        DrawFreeSpace();
//    }

//    private void ChangePlatformHeight()
//    {

//    }

//    private void DrawFreeSpace()
//    {
//        int maxHeight = 9;
//        int generetionLength = 14 * 2;
//        int maxFreeSpace = 2;
//        int step = 1;
//        //_tilemap.SetTile(_paintorStartPosiotion, null); //�������� �����

////    }
//}
