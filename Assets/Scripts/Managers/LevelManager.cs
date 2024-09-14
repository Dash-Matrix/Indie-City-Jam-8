using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private int timerSeconds;

    [SerializeField] private ItemData[] items;

    [SerializeField] private level[] levels;

    public void GameStart()
    {
        timer.StartTimer(timerSeconds);
        levels[0].UpdateShelf(items);
    }

    public void GameStop()
    {
        timer.isRunning = false;
    }
}
