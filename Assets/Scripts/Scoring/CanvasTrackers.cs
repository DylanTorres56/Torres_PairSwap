using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasTrackers : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTracker; // The text displaying the player's current score.
    [SerializeField] TextMeshProUGUI lifeTracker; // The text displaying the player's current lives.

    [SerializeField] int scoreCount; // The amount of points the player has. Score is gained upon striking bricks.
    [SerializeField] int lifeCount; // The amount of lives the player has. Lives are lost when no ball is active.

    // Start is called before the first frame update
    void Start()
    {
        scoreTracker.text = $"SCORE: {scoreCount}";
        lifeTracker.text = $"LIVES: {lifeCount}";
    }

    // When this Canvas is enabled, it subscribes to the OnBrickStruck and OnLifeLost delegates.
    private void OnEnable()
    {
        Brick.OnBrickStruck += IncrementScoreCount;
        Ball.OnLifeLost += DecrementLifeCount;
    }

    // When this Canvas is disabled, it unsubscribes to the OnBrickStruck and OnLifeLost delegates.
    private void OnDisable()
    {
        Brick.OnBrickStruck -= IncrementScoreCount;
        Ball.OnLifeLost -= DecrementLifeCount;
    }

    public void IncrementScoreCount() 
    {
        scoreCount += 100;
        scoreTracker.text = $"SCORE: {scoreCount}";
    }

    public void DecrementLifeCount()
    {
        lifeCount--;
        lifeTracker.text = $"LIVES: {lifeCount}";
    }
}
