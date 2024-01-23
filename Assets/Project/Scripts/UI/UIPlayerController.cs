using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIPlayerController : MonoBehaviour {
   
    private PlayerController playerController;

    [Inject]
    public void Construct(PlayerController playerController) {
        this.playerController = playerController;
    }

    public void TouchLeftButton() {
        playerController.OnMoveLeft();
    }
    public void TouchRightButton() {
        playerController.OnMoveRight();
    }
}

