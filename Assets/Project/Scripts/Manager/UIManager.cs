using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private int difficultyLevel = 1;



    [Header ("Menu")]
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject pauseScreen;
    [Header ("Score and level")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text difficultyLevelText;
    [Space (20)]
    [SerializeField] private ScoreManager scoreManager;

    private void OnEnable() {
        ScoreManager.UpdateScore += UpdateScore;
        GameManager.UpdateDifficultyLevel += UpdateDifficultyLevel;
        GameManager.StopGameOn += GameOverOn;
        PauseMenu.PauseEnable += PauseScreenOn;
        PauseMenu.PauseDisable += PauseScreenOff;
    }

    private void OnDisable() {
        ScoreManager.UpdateScore -= UpdateScore;
        GameManager.UpdateDifficultyLevel -= UpdateDifficultyLevel;
        GameManager.StopGameOn -= GameOverOn;
        PauseMenu.PauseEnable -= PauseScreenOn;
        PauseMenu.PauseDisable -= PauseScreenOff;
    }

    private void Awake() {
        difficultyLevelText.text = difficultyLevel.ToString();
    }

    private void UpdateScore() {
        scoreText.text = scoreManager.PlayerScore.ToString();
    }

    private void UpdateDifficultyLevel() {
        difficultyLevel++;
        difficultyLevelText.text = difficultyLevel.ToString();
    }
    
    private void GameOverOn() {
        deadScreen.SetActive(true);
    }

    private void PauseScreenOn() {
        pauseScreen.SetActive(true);
    }

    private void PauseScreenOff() {
        pauseScreen.SetActive(false);
    }
}
