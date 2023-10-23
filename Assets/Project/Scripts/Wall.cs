using UnityEngine;

public class Wall : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float deadLine = -30f;
    [SerializeField] private GameManager gameLogic;

    

    private void Start() {
        gameLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameManager>();
        moveSpeed = gameLogic.MoveSpeedGate;
    }

    void Update() {
        MoveWall();
        DestroyWall();
        moveSpeed = gameLogic.MoveSpeedGate;
    }

    private void MoveWall() {
        transform.position = transform.position + (Vector3.back * moveSpeed) * Time.deltaTime;
    }

    private void DestroyWall() {
        if (transform.position.z < deadLine) {
            Destroy(gameObject);
        }
    }
}
