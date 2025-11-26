using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string nextLevelName;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
