using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static event System.Action OnStartGame;

    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Text gameOverMessageContener;

    void Awake() {
        GameManager.OnGameOver += DisplayGameOver;
    }

    void OnDestroy() {
        GameManager.OnGameOver -= DisplayGameOver;
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
        SceneController.ReloadScene();
    }

    void DisplayGameOver(bool isWin){
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
        if(isWin) {
            DispayGameOverWinUI();
        } else {
            DispayGameOverLoseUI();
        }
    }

    void DispayGameOverWinUI() {
        gameOverMessageContener.color = Color.green;
        gameOverMessageContener.text = "You Win";
        Debug.Log("You Win");
    }

    void DispayGameOverLoseUI() {
        gameOverMessageContener.color = Color.red;
        gameOverMessageContener.text = "You Lose";
        Debug.Log("You Lose");
    }
}
