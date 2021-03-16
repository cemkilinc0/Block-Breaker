using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f , 10f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointBlock = 20;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int score = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void SelectDifficulty(string dif)
    {
        if (dif == "easy")
        {
            gameSpeed = 1f;
        }
        else if (dif == "medium")
        {
            gameSpeed = 1.3f;
        }
        else if (dif == "hard")
        {
            gameSpeed = 1.5f;
        }
    }

    public void addToScore()
    {
        score += pointBlock;
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
