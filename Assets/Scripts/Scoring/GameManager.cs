using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTracker; // The text displaying the player's current score.
    [SerializeField] TextMeshProUGUI lifeTracker; // The text displaying the player's current lives.

    [SerializeField] int scoreCount; // The amount of points the player has. Score is gained upon striking bricks.
    [SerializeField] int lifeCount; // The amount of lives the player has. Lives are lost when no ball is active.

    [SerializeField] int scoreToClear; // The required score needed to clear the level. MUST BE DIVISIBLE BY 100!
    [SerializeField] int gameOverScreenIndex; // When getting a Game Over, go to this screen.

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

        if (scoreCount == scoreToClear) 
        {
            SceneManager.LoadScene(gameOverScreenIndex); // Transport the player to Game Over!
        }
    }

    public void IncrementLifeCount()
    {
        lifeCount++;
        lifeTracker.text = $"LIVES: {lifeCount}";
    }

    public void DecrementLifeCount()
    {
        lifeCount--;
        lifeTracker.text = $"LIVES: {lifeCount}";

        if (lifeCount <= 0) 
        {
            SceneManager.LoadScene(gameOverScreenIndex); // Transport the player to Game Over!            
        }
    }

}
