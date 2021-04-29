using UnityEngine; // using UnityEditor.UIElements;

namespace Player.Attack {
    public class Arrow : MonoBehaviour {
        private Rigidbody body;
        public float attackDamage = 10f;
        private bool usedUp = false;

        // Start is called before the first frame update
        void Start() {
            body = GetComponent<Rigidbody>();
            // transform.rotation = Quaternion.LookRotation(body.velocity);
        }


        // on collision
        private void OnCollisionEnter(Collision other) {
            // if it is the player then ignore
            if (other.collider.CompareTag("player"))
                return;
            
            // 11 is life layer
            if (!usedUp && other.gameObject.layer == 11) {
                // apply damage and spawn particles on contact point
                if (other.gameObject.GetComponent<Stats.Stats>() != null) {
                    other.gameObject.GetComponent<Stats.Stats>().ApplyDamage(attackDamage, other.GetContact(0).point,other.transform.rotation);
                    usedUp = true;// arrow has been used up so it will not do damage again
                }

            }
        }
    }
}