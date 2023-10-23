using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField] GameManager gameManager;
    private Vector3 targetPos;
    private float laneOffset = 3;
    [SerializeField] private float moveSpeed = 20;
    
    private void Start() {
        targetPos = transform.position;
    }

 
    private void Update() {
        MoveController();
    }

    private void MoveController() {
        if (gameManager.PauseGame != true) {
            if (Input.GetKeyDown(KeyCode.A) && targetPos.x > -laneOffset) {
                targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset) {
                targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void OnTouchButtonLeft() {
        if (targetPos.x > -laneOffset) {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
        }
    }
    public void OnTouchButtonRight() {
        if (targetPos.x < laneOffset) {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
        }
    }
}
