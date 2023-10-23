using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    private float time;

    public static Action PauseEnable;
    public static Action PauseDisable;

    private void Awake() {
        time = Time.timeScale;
    }

    public void Pause() {
        Time.timeScale = 0;
        time = Time.timeScale;
        PauseEnable?.Invoke();
    }

    public void Continue() {
        Time.timeScale = 1;
        time = Time.timeScale;
        PauseDisable?.Invoke();
    }
    
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        time = Time.timeScale;
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        time = Time.timeScale;
    }
}
