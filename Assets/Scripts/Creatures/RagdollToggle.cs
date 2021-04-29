using System.Linq;
using UnityEngine;


// Ragdoll Tutorial : https://youtu.be/oVPI2ESkgIw
// Changes have been made to make it more compatible
namespace Creatures {
    
    // component gets attached to a character with the box collider with a ragdoll setup (Colliders, and Character Joints on apporpriate bones)
    public class RagdollToggle : MonoBehaviour {
    
        // Get the elements to disable and enable for enabling the Ragdoll
        private Animator animator;
        // protected Rigidbody rigidbody;
        private BoxCollider boxCollider;
        // protected Sabertooth sabertooth;
        public Behaviour aiComponent;
    
        // children physics elements
        private Collider[]  childrenColliders;
        private Rigidbody[] childrenRigidbodies;

        // store the current state for efficiency purposes
        private bool currentState;
    
    
        void Awake() {
            // cache references to the components
            animator = GetComponentInChildren<Animator>();
            boxCollider = GetComponent<BoxCollider>();
            // Using System.Linq to avoid getting the parent in the children list:
            // http://answers.unity.com/answers/1248479/view.html
            childrenColliders = this.GetComponentsInChildren<Collider>(true).Where(x => x.gameObject.transform.parent != transform.parent).ToArray();
        
            childrenRigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        private void Start() {
        
            // disable the ragdoll at the beginning
            currentState = true;
            EnableRagdoll(false);
        }


        public void EnableRagdoll(bool isActive) {

            if (currentState != isActive) {
            
                // children colliders
                foreach (var collider in childrenColliders) {
                    collider.enabled = isActive;
                }

                // children rigidbody
                foreach (var rigidbody in childrenRigidbodies) {
                    rigidbody.detectCollisions = isActive;
                    rigidbody.isKinematic = !isActive;
                }

                // parent
                animator.enabled = !isActive;
                boxCollider.enabled = !isActive;
                aiComponent.enabled = !isActive;
                // for efficiency 
                currentState = isActive;
            }
        }
    
    }
}
