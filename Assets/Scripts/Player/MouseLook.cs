using UnityEngine;

namespace Player {
    // Unity Tutorial 2019 from
    // Brakey's "First Person Movement in Unity - FPS Controller":
    // https://youtu.be/_QajrabyTJc
    // Has been updated by Aum Patel
    public class MouseLook : MonoBehaviour {
        public float mouseSensitivity = 100f;

        public Transform playerBody;

        private float xRotation = 0f;

        public void Start() {
            // lock the cursor inside the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update() {
            // get mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            // update camera rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // update player's rotation
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}