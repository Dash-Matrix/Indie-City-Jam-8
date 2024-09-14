using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SFXManager.instance.StartGamePlayThemeMusic();
    }

    public void GameStart()
    {
        playerMovement.SetActiavtion(true);
        levelManager.GameStart();
        uiManager.GameStart();
    }

    public void Won()
    {
        playerMovement.SetActiavtion(false);
        levelManager.GameStop();
        uiManager.Won();
    }

    public void Lose()
    {
        playerMovement.SetActiavtion(false);
        levelManager.GameStop();
        uiManager.Lost();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
