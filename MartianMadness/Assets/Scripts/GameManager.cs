using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI scoreText;
    public Canvas gameOverCanvas;
    public Canvas startGameCanvas;

    private SpawnManager spawnManager;

    public bool isGameOver = true;
    public bool isGameStarted = false;
    public static bool isGameRestarted;

    private int upgradeRun = 1;

    // Start is called before the first frame update
    void Start()
    {        
        scoreText.text = "Score: " + score;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (!isGameStarted) { startGameCanvas.gameObject.SetActive(true); }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver && isGameStarted)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }

        if(isGameRestarted)
        {
            startGameCanvas.gameObject.SetActive(false);
            GameStartState();
            if ((upgradeRun++) > 50)
            {
                isGameRestarted = false;
                upgradeRun = 1;
            }
        }

    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score < 0)
        {
            isGameOver = true;
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameRestarted = true;        
    }

    public void GameStartState()
    {
        startGameCanvas.gameObject.SetActive(false);
        isGameOver = false;
        isGameStarted = true;
        spawnManager.numOfEnemies = 1;
    }

}
