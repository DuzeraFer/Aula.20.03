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

    public TextMeshProUGUI scoreText, timerText, lifesText, scoreGameOverText;
    public GameObject gameMenu, gameOverMenu, startMenu;

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
            gameMenu.SetActive(false);
            gameOverMenu.SetActive(true);
            scoreGameOverText.text = "SCORE: " + _GameManager.score.ToString();

            foreach (var item in spawnManager.spawnedObjects)
            {
                if (item != null) item.GetComponent<_MoveObject>().DestroyObjs();
            }
        }
     
        timerText.text = "TIME: " + _GameManager.timer.ToString("F0");
        scoreText.text = "SCORE: " + _GameManager.score.ToString();
        lifesText.text = "LIFES: " + _GameManager.lifes.ToString();
        scoreGameOverText.text = "SCORE: " + _GameManager.score.ToString();
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

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
