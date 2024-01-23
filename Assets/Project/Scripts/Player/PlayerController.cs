using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.OnScreen;
using Zenject;

public class PlayerController : MonoBehaviour {

    private GameManager gameManager;

    private Vector3 targetPos;
    private float laneOffset = 3;
    private float moveSpeed = 20;


    [Inject]
    public void Construct(GameManager gameManager) {
        this.gameManager = gameManager;

    }

    private void Start() {
        targetPos = transform.position;
    }
 
    private void Update() {
        Movement();
        GetTransformPosition();
    }

    private void Movement() {
        
        if (Input.GetKeyDown(KeyCode.A)) {
            if (gameManager.PauseGame != true) {
                if (targetPos.x > -laneOffset) {
                    targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (gameManager.PauseGame != true) {
                if (targetPos.x < laneOffset) {
                    targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
                }
            }
        }
    }


    public void GetTransformPosition() {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void OnMoveLeft() {
        if (gameManager.PauseGame != true) {
                if (targetPos.x > -laneOffset) {
                    targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
                }
            }
        }

    public void OnMoveRight() {
        if (gameManager.PauseGame != true) {
                if (targetPos.x < laneOffset) {
                    targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
                }
            }
        }


   
}
