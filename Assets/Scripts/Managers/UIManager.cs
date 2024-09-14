using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject GameplayScreen;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;


    public void GameStart()
    {
        ActivateScreen(GameplayScreen);
    }
    public void Won()
    {
        ActivateScreen(WinScreen);
    }
    public void Lost()
    {
        ActivateScreen(LoseScreen);
    }

    private void ActivateScreen(GameObject screen)
    {
        StartScreen.SetActive(false);
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

        screen.SetActive(true);
    }
}
