using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;
    public Player player;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public Transform GetPlayerTransform() {
        if (player != null) {
            return player.transform;
        }
        else {
            Debug.LogError("Player reference is not set in PlayerManager.");
            return null;
        }
    }
}
