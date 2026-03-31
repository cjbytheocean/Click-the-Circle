using UnityEngine;

public class ClickedCircle : MonoBehaviour
{
    public GameBehavior gb;

    void Awake()
    {
        gb = FindAnyObjectByType<GameBehavior>();
    }
    void OnMouseDown()
    {
        gb.timerRunning = false;

        if (gb.timer > gb.highScore)
        {
            gb.highScore = gb.timer;
            JSONManager.instance.SaveData();
        }
        gb.highScoreText.text = $"High Score: {gb.highScore}s";
        gb.restartText.SetActive(true);
    }
}
