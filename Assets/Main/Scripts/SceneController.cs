using UnityEngine.SceneManagement;

public class SceneController
{
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
