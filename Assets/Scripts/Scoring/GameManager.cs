using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTracker; // The text displaying the player's current score.
    [SerializeField] TextMeshProUGUI lifeTracker; // The text displaying the player's current lives.
    [SerializeField] GameObject gameOverPopup; // Rather than a new screen, a pop-up window will appear.
    [SerializeField] SpawnBall ballSpawner;

    [SerializeField] int scoreCount; // The amount of points the player has. Score is gained upon striking bricks.
    [SerializeField] int lifeCount; // The amount of lives the player has. Lives are lost when no ball is active.

    [SerializeField] int scoreToClear; // The required score needed to clear the level. MUST BE DIVISIBLE BY 100!
    [SerializeField] int nextStageIndex; // Index of the next stage. Replaced by Stage 1 if all stages have been cleared.
    [SerializeField] int finalStageIndex; // Index of the final stage. To be updated when new levels are added. 
    [SerializeField] int gameOverScreenIndex; // When getting a Game Over, go to this screen.

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scoreTracker.text = $"SCORE: {scoreCount}";
        lifeTracker.text = $"LIVES: {lifeCount}";
        gameOverPopup.SetActive(false);
        nextStageIndex = PlayerPrefs.GetInt("nSI");
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

    // Add points to the score count. If the score to clear the stage is met, move to the next stage or loop from Stage 1!
    public void IncrementScoreCount() 
    {
        scoreCount += 100;
        scoreTracker.text = $"SCORE: {scoreCount}";

        if (scoreCount == scoreToClear) 
        {
            IncrementStageCount();
            SceneManager.LoadScene(nextStageIndex);
        }
    }

    public void IncrementStageCount() 
    {
        nextStageIndex++;
        if (nextStageIndex > finalStageIndex) 
        {
            nextStageIndex = 1;
        }

        PlayerPrefs.SetInt("nSI", nextStageIndex);
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
            PopUpGameOver();
        }
    }

    // When the Game Over menu pops up, don't spawn any more balls!
    private void PopUpGameOver() 
    {        
        Ball.OnLifeLost -= DecrementLifeCount;
        gameOverPopup.SetActive(!gameOverPopup.activeSelf);
        StartCoroutine(FreezeGame());
    }

    IEnumerator FreezeGame() 
    {
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 0;
    }
}
