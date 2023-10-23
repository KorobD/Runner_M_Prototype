using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int playerScore;
    [Header ("Score")]
    [SerializeField] private int scoreGate = 1;

    public int PlayerScore { get { return playerScore; } }

    public static Action PassesOfGate;
    public static Action UpdateScore;

    private void OnEnable() {
        Player.OnTriggerEnterGate += AddScoreGate;
    }

    private void OnDisable() {
        Player.OnTriggerEnterGate -= AddScoreGate;
    }

    public void AddScoreGate() {
        playerScore += scoreGate;
        PassesOfGate?.Invoke();
        UpdateScore?.Invoke();
    }
}
