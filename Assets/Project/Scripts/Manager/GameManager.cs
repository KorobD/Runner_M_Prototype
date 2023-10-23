using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private bool startGame = false;
    private bool stopGame = false;
    private bool pauseGame = false;
    private bool canSpawnGate;

    private int namberOfPasses;
    private int difficultyLevel = 1;
    private float moveSpeedGate = 50f;
    private float timeSpawnGate = 1.2f;

    public bool PauseGame { get { return pauseGame; } }
    public bool StopGame { get { return stopGame; } }
    public bool StartGame { get { return startGame; } }
    public bool CanSpawnGate { get { return canSpawnGate; } }
    public float MoveSpeedGate { get { return moveSpeedGate; } }
    public float TimeSpawnGate { get { return timeSpawnGate; } }

    public static Action UpdateDifficultyLevel;
    public static Action PauseGameOn;
    public static Action StopGameOn;


    private void OnEnable() {
        Player.PlayerDied += PlayerIsDead;
        ScoreManager.PassesOfGate += IncreasingDifficulty;
        PauseMenu.PauseEnable += PauseActivity;
        PauseMenu.PauseDisable += PauseDeactivity;
    }

    private void OnDisable() {
        Player.PlayerDied -= PlayerIsDead;
        ScoreManager.PassesOfGate -= IncreasingDifficulty;
        PauseMenu.PauseEnable -= PauseActivity;
        PauseMenu.PauseDisable -= PauseDeactivity;
    }

    private void Awake() {
        startGame = true;
        canSpawnGate = true;
    }

    public void PlayerIsDead() {
        canSpawnGate = false;
        stopGame = true;
        StopGameOn?.Invoke();
    }

    private void IncreasingDifficulty() {
        namberOfPasses++;
        if (namberOfPasses > 1) {
            if (namberOfPasses % 10 == 0) {
            moveSpeedGate = moveSpeedGate + 10;
            AddDifficultyLvL();
            UpdateDifficultyLevel?.Invoke();
            }
        }
    }

    private void AddDifficultyLvL() {
        difficultyLevel = difficultyLevel + 1;
    }

    private void PauseActivity() {
        pauseGame = true;
    }

    private void PauseDeactivity() {
        pauseGame = false;
    }
}
