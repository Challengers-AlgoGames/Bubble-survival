using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event System.Action OnGameOver;

    [SerializeField] GameObject player;
    [SerializeField] GameObject soap;

    void Awake() {
        UIManager.OnStartGame += Play;
        PlayerHealth.OnPlayerDeath += Defeat;

        player.SetActive(false);
        soap.SetActive(false);
    }
    
    void OnDestroy() {
        PlayerHealth.OnPlayerDeath -= Defeat;
        UIManager.OnStartGame -= Play;
    }

    void Play() {
        player.SetActive(true);
        soap.SetActive(true);
    }

    void GameOver() {
        OnGameOver?.Invoke();
        player.SetActive(false);
        soap.SetActive(false);
    }

    void Defeat() {
        GameOver();
    }
}
