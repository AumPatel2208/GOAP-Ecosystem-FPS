using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Player.Attack {
    public class ArrowAttack : MonoBehaviour {
        // the arrow to shoot
        public GameObject arrowPrefab;
        public Camera     mainCamera;

        // arrow forces
        public  float baseArrowForce = 3f; // minimum force at which it wil go
        public  float maxArrowForce;       // changed in inspector
        private float arrowForce     = 0f; // the force added to base arrow force to shoot
        public  float incrementValue = 0.5f; // the speed at which the force incremented
        
        // time to delete the instance of the arrow
        public float deleteTime = 2f;

        // whether the right click is held down
        private bool isKeyDown = false;

        // for the charge meter Hud element
        public Image arrowChargeMeter;

        private void Start() {
            // get the charge meter
            if (arrowChargeMeter == null) {
                arrowChargeMeter = GameObject.Find("ArrowChargeMeter").GetComponent<Image>();
            }
        }

        void Update() {
            // when pressing right click down
            if (Input.GetButtonDown("Fire2")) {
                isKeyDown = true;
            }

            // when releasing right click
            if (Input.GetButtonUp("Fire2")) {
                isKeyDown = false;
                // position to instantiate arrow
                var pos = transform.position;
                pos += 2f * transform.right;
                GameObject arrow = Instantiate(arrowPrefab, pos, transform.rotation);
                arrow.transform.localScale += new Vector3(2, 2, 2);
                // apply force that was building up in the forward direction of the camera
                arrow.GetComponent<Rigidbody>().velocity = mainCamera.transform.forward * (baseArrowForce + arrowForce);
                Destroy(arrow, deleteTime);
                // reset arrow force
                arrowForce = 0f;
            }

            // update the GUI
            arrowChargeMeter.fillAmount = arrowForce / maxArrowForce;
        }

        private void FixedUpdate() {
            // if the key is down then increment the arrow force
            if (isKeyDown && arrowForce<=maxArrowForce) {
                arrowForce += incrementValue;
            }
        }
    }
}