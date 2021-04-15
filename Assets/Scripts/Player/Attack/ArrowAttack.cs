using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Player.Attack {
    public class ArrowAttack : MonoBehaviour {
        public GameObject arrowPrefab;
        public Camera mainCamera;

        public float baseArrowForce = 3f;
        public float maxArrowForce;
        
        public float deleteTime = 2f;
        public float incrementValue = 0.5f;

        private bool isKeyDown = false;

        private float arrowForce = 0f;

        public Image arrowCharge;
        
        // Update is called once per frame
        void Update() {
            if (Input.GetButtonDown("Fire2")) {
                isKeyDown = true;
            }

            if (Input.GetButtonUp("Fire2")) {
                isKeyDown = false;
                var pos = transform.position;
                pos += 2f * transform.right;
                GameObject arrow = Instantiate(arrowPrefab, pos, transform.rotation);
                arrow.transform.localScale += new Vector3(2, 2, 2);
                arrow.GetComponent<Rigidbody>().velocity = mainCamera.transform.forward * (baseArrowForce + arrowForce);
                Object.Destroy(arrow, deleteTime);
                arrowForce = 0f;
            }

            arrowCharge.fillAmount = arrowForce / maxArrowForce;
        }

        private void FixedUpdate() {
            if (isKeyDown && arrowForce<=maxArrowForce) {
                arrowForce += incrementValue;
                Debug.Log("Arrow Force: "+ arrowForce);
            }
        }
    }
}