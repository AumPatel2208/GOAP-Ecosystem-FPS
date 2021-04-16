using UnityEngine;

namespace Player {
    public class PlayerSpawn : MonoBehaviour {

        public GameObject player;

        public GameObject playerPrefab;
        
        
        // Start is called before the first frame update
        void Start() {
            player = GameObject.Find("Player");
            if (player == null) {
                player = playerPrefab;
            }
        }

        // Update is called once per frame
        void Update() {
            // respawn
            if (player == null) {
                player = Instantiate(playerPrefab, transform);
            }
        }
    }
}