using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action<bool> OnGameOver;

    [SerializeField] GameObject player;
    [SerializeField] GameObject soap;

    void Awake()
    {
        UIManager.OnStartGame += Play;
        PlayerHealth.OnPlayerDeath += Defeat;
        TimerManager.OnTimerOut += Win;

        player.SetActive(false);
        soap.SetActive(false);
    }

    void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= Defeat;
        UIManager.OnStartGame -= Play;
        TimerManager.OnTimerOut -= Win;
    }

    void Play()
    {
        player.SetActive(true);
        soap.SetActive(true);
    }

    void GameOver(bool isWin)
    {
        OnGameOver?.Invoke(isWin);
        player.SetActive(false);
        soap.SetActive(false);
    }

    void Defeat()
    {
        GameOver(false);
    }

    void Win()
    {
        GameOver(true);
    }
}
