using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private void StopGame() //�������� ������ ��������� ���� (������)
    {
        Time.timeScale = 0;
    }

    private void StartGame() //������ ���� � ����
    {
        Time.timeScale = 1; //�������� ����� ������� ���������� ���������� �� ���� ����������� ����,
                            //����� ���� ������� ������ (������ ��� �������, ��� ��� ��������� �������� � �� ���� ���������� �������)
    }

    private void PauseGame()
    {
        Time.timeScale = 0; //���������� ���� � ��. ������� ����
    }

    private void ContinueGame()
    {
        Time.timeScale = 1; //������ ������� �������� ���������� ��������� ��������
    }
}
