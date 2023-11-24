using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Action OnTriggerEnterGate;
    public static Action PlayerDied;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Wall")) {
            //PlayerDied?.Invoke();
            //Destroy(gameObject);
            Debug.Log("Стена");
        }
        if (other.gameObject.CompareTag("Gate")) {
            OnTriggerEnterGate?.Invoke();
            Debug.Log("Ворота");
        }
    }
}
