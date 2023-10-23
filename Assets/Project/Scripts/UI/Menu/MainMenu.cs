using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayPressed() {
        SceneManager.LoadScene("Game");
    }
    public void ExitPressed() {
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
