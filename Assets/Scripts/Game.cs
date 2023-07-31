using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    private void Awake()
    {
        _mainMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void StopGame() //добавить строки окончания игры (сброса)
    {
        Time.timeScale = 0f;
    }

    public void StartGame() //запуск игры с нуля
    {
        Time.timeScale = 1f;
        _mainMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; //показывать меню и др. строчки кода
        _mainMenu.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f; //вместо единицы задавать переменную актульной скорости
    }
}
