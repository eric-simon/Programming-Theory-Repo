using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int Level = 1;

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

    public void FinishGame()
    {
        StartCoroutine(FinishGameCoroutine());
    }

    IEnumerator PauseGameCoroutine()
    {
        Time.timeScale = 0;

        float pauseEndTime = Time.realtimeSinceStartup + 5;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }

        Time.timeScale = 1;
    }

    IEnumerator FinishGameCoroutine()
    {
        Level++;

        yield return PauseGameCoroutine();

        LoadGameScene();
    }

    public void LoseLife()
    {
        StartCoroutine(LoseLifeCoroutine());
    }

    IEnumerator LoseLifeCoroutine()
    {
        ScoreManager.Instance.LoseLife();

        yield return new WaitForSeconds(5);

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