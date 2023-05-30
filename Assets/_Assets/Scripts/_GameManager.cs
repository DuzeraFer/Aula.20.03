using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{
    public static float score = 0;
    public static float timer = 0;
    public static int lifes = 3;

    public static TextMeshProUGUI scoreText, timerText, lifesText, pointsGameOverText, pointsVictoryText, timeLeftGameOverText, timeLeftVictoryText, lifesLeftGameOverText, lifesLeftVictoryText;
    public static GameObject gameMenu, gameOverMenu, startMenu, victoryMenu;

    public _SpawnManager spawnManager;

    public static bool startGame;

    private void Update()
    {
        if (!_GameManager.startGame) return;

        _GameManager.timer -= Time.deltaTime;
        if (_GameManager.timer <= 0 || lifes == 0)
        {
            _GameManager.startGame = false;
            _GameManager.timer = 0;

            GameOver();       

            foreach (var item in spawnManager.spawnedObjects)
            {
                if (item != null) item.GetComponent<_MoveObject>().DestroyObjs();
            }
        }
     
        timerText.text = "TIME: " + _GameManager.timer.ToString("F0");
        scoreText.text = "SCORE: " + _GameManager.score.ToString();
        lifesText.text = "LIFES: " + _GameManager.lifes.ToString();
    }

    public void StartGame()
    {
        _GameManager.score = 0;
        _GameManager.timer = 100;
        _GameManager.lifes = 3;
        _GameManager.startGame = true;

        startMenu.SetActive(false);
        gameMenu.SetActive(true);

        GameObject.Find("SpawnManager").GetComponent<_SpawnManager>().StartSpawn();
    }

    public static void IncScore(int score, int timer, int lifes)
    {
        _GameManager.score += score;
        _GameManager.timer += timer;
        _GameManager.lifes -= lifes;
    }

    public static void Victory()
    {
        pointsVictoryText.text = "SCORE: " + _GameManager.score.ToString();
        lifesLeftVictoryText.text = "SCORE: " + _GameManager.score.ToString();
        timeLeftVictoryText.text = "SCORE: " + _GameManager.score.ToString();

        gameMenu.SetActive(false);
        victoryMenu.SetActive(true);
    }

    public void GameOver()
    {
        pointsGameOverText.text = "SCORE: " + _GameManager.score.ToString();
        timeLeftGameOverText.text = "SCORE: " + _GameManager.score.ToString();
        lifesLeftGameOverText.text = "SCORE: " + _GameManager.score.ToString();

        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
