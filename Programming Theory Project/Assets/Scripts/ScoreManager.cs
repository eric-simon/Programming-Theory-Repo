using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //ENCAPSULATION
    public static ScoreManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PrintScore();
    }

    [SerializeField]
    private Text ScoreText;

    private int score = 0;

    private int lives = 3;

    private void PrintScore()
    {
        if (lives == 0)
        {
            ScoreText.text = $"GAME OVER Score: {score}";
        }
        else
        {
            ScoreText.text = $"Score: {score} Lives: {lives}";
        }
    }

    public void IncreaseScore()
    {
        if (lives > 0)
        {
            score = score + 1;

            PrintScore();
        }
    }

    public bool IsGameOver()
    {
        return lives == 0;
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives = lives - 1;

            PrintScore();
        }
    }
}
