using UnityEngine;

namespace Player.Attack {
    public class SwordAttack : MonoBehaviour {
        public Animator animator;
        // damage value
        public float attackDamage = 50f;
        // stamina cost
        public float staminaCost = 15f;

        // refrence to name of animation state
        private static readonly int hIsAttacking = Animator.StringToHash("isAttacking");
        public Stats.Stats playerStats;

        // number of clicks
        int noOfClicks;
        private bool canClick;
        private static readonly int hAttackNo = Animator.StringToHash("attackNo");

        // Start is called before the first frame update
        void Start() {
            animator.GetComponent<Animator>();
            noOfClicks = 0;
            canClick = true;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetButtonDown("Fire1") && playerStats.GetStamina() > staminaCost) {
                playerStats.ApplyStaminaReduction(staminaCost);
                ComboStarter();
            }

            // Below is a fix to a known bug where the animation gets stuck
            // Added to reset the stuck animation if they click more than 3 times.
            if (noOfClicks > 3) {
                animator.SetInteger(hAttackNo, 0);
                noOfClicks = 0;
                canClick = true;
            }
        }


        private void OnTriggerEnter(Collider other) {
            // If it is the player then ignore
            if (other.CompareTag(transform.root.tag))
                return;
            // if the player is in a state of attacking 
            if (animator.GetInteger(hAttackNo) > 0) {
                // 11 is life layer
                if (other.gameObject.layer == 11) {
                    if (other.gameObject.GetComponent<Stats.Stats>() != null) {
                        other.gameObject.GetComponent<Stats.Stats>().ApplyDamage(attackDamage, other.bounds.center, other.transform.rotation);
                    }
                }
            }
        }

        private void ComboStarter() {
            if (canClick) {
                noOfClicks++;
            }

            if (noOfClicks == 1) {
                animator.SetInteger(hAttackNo, 1);
            }
        }

        public void ComboCheck() {
            // Combo System tutorial: https://youtu.be/NWt84YCMHHE Reference
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_1") && noOfClicks == 1) {
                // set to idle
                animator.SetInteger(hAttackNo, 0);

                // reset
                canClick = true;
                noOfClicks = 0;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_1") && noOfClicks >= 2) {
                // change to next attack
                animator.SetInteger(hAttackNo, 2);

                //reset
                canClick = true;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_2") && noOfClicks == 2) {
                // Debug.Log("swing2 and noCLicks 2");
                // set to idle
                animator.SetInteger(hAttackNo, 0);

                // reset
                canClick = true;
                noOfClicks = 0;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_2") && noOfClicks >= 3) {
                // change to next attack
                animator.SetInteger(hAttackNo, 3);

                //reset
                canClick = true;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_3")) {
                // set to idle
                animator.SetInteger(hAttackNo, 0);

                // reset
                canClick = true;
                noOfClicks = 0;
            }
        }
    }
}