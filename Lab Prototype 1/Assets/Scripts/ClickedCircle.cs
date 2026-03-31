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
        gb.highScoreText.text = $"High Score: {gb.timer}s";
        gb.restartText.SetActive(true);
    }
}
