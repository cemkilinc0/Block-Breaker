using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadEasy()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameStatus>().SelectDifficulty("easy");
    }

    public void LoadMedium()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameStatus>().SelectDifficulty("medium");
    }

    public void LoadHard()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameStatus>().SelectDifficulty("hard");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
