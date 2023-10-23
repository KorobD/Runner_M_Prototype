using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }

}
