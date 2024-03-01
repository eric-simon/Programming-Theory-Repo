using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoseLife()
    {
        ScoreManager.Instance.LoseLife();

        if (ScoreManager.Instance.IsGameOver())
        {
            LoadMenu();
        }
        else
        {
            LoadGameScene();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}