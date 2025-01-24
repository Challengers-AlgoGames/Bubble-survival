using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static event System.Action OnStartGame;

    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameOverUI;

    void Awake() {
        Game.OnGameOver += DisplayGameOver;
    }

    void OnDestroy() {
        Game.OnGameOver -= DisplayGameOver;
    }

    void Start() {
        startUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void StartGame() {
        startUI.SetActive(false);
        OnStartGame?.Invoke();
    }

    public void RestartGame() {
        OnStartGame?.Invoke();
        gameOverUI.SetActive(false);
    }

    void DisplayGameOver(){
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
    }
}
