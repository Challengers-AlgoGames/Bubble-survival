using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action<bool> OnGameOver;

    [SerializeField] GameObject player;
    [SerializeField] GameObject soap;
    [SerializeField] GameObject text;

    void Awake()
    {
        UIManager.OnStartGame += Play;
        PlayerHealth.OnPlayerDeath += Defeat;
        TimerManager.OnTimerOut += HandleTimerOut;

        player.SetActive(false);
        soap.SetActive(false);
        text.SetActive(false);
    }

    void OnDestroy()
    {
        PlayerHealth.OnPlayerDeath -= Defeat;
        UIManager.OnStartGame -= Play;
        TimerManager.OnTimerOut -= HandleTimerOut;
    }

    void Play()
    {
        player.SetActive(true);
        soap.SetActive(true);
        text.SetActive(true);
    }

    void GameOver(bool isWin)
    {
        OnGameOver?.Invoke(isWin);
        player.SetActive(false);
        soap.SetActive(false);
        text.SetActive(false);
    }

    void Defeat()
    {
        GameOver(false);
    }

    void Win()
    {
        GameOver(true);
    }

    void HandleTimerOut()
    {
        Debug.Log("Le temps est écoulé, défaite !");
        Win();
    }
}
