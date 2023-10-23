using UnityEngine;

public class WallGeneration : MonoBehaviour {

    [SerializeField] private GameObject[] gates;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float timeSpawn = 1.2f;
    
    void Start() {
        timeSpawn = gameManager.TimeSpawnGate;
        InvokeRepeating(methodName: "SpawnGate", time: 0, repeatRate: timeSpawn);
    }

    void Update() {

    }

    private void SpawnGate() {
        if (gameManager.CanSpawnGate && gameManager.StartGame) {
        int ndx = Random.Range(0, gates.Length);
        GameObject go = Instantiate<GameObject>(gates[ndx]);
        }
    }
}
