using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Function to load a scene based on the scene name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
