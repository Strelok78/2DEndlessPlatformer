using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private void StopGame() //добавить строки окончания игры (сброса)
    {
        Time.timeScale = 0;
    }

    private void StartGame() //запуск игры с нуля
    {
        Time.timeScale = 1; //возможно стоит сделать изменяемой переменной по мере прохождения игры,
                            //чтобы было сложнее играть (только для раннера, тут это негативно скажется и не даст требуемого эффекта)
    }

    private void PauseGame()
    {
        Time.timeScale = 0; //показывать меню и др. строчки кода
    }

    private void ContinueGame()
    {
        Time.timeScale = 1; //вместо единицы задавать переменную актульной скорости
    }
}
