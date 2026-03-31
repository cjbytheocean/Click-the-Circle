using UnityEngine;
using TMPro;
using System;

public class GameBehavior : MonoBehaviour
{
    public bool gameStarted = false;
    public bool timerRunning = false;
    public bool circleClicked = false;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] public TextMeshProUGUI highScoreText;
    [SerializeField] GameObject instructionsText;
    [SerializeField] public GameObject restartText;

    public float timer = 0f;
    public float highScore = 0f;

    void Start()
    {
        var data = JSONManager.instance.LoadData();
        highScore = data.playerData.highScore;
        highScoreText.text = $"High Score: {highScore}s";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !gameStarted)
        {
            gameStarted = true;
            StartTheGame();
        }

        if (timerRunning)
        {
            timer += Time.deltaTime;
            timeText.text = $"Time Elapsed: {timer}s";
        }

    }

    void StartTheGame()
    {
        instructionsText.SetActive(false);
        timerRunning = true;
    }
}
