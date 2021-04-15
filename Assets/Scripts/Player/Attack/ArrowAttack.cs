using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour {

    public GameObject arrowPrefab;
    public Camera mainCamera;

    public float arrowForce = 20f;
    public float deleteTime = 2f;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            var pos = transform.position;
            pos += 2f * transform.right;
            GameObject arrow = Instantiate(arrowPrefab, pos, transform.rotation);
            arrow.transform.localScale += new Vector3(2, 2, 2);
            arrow.GetComponent<Rigidbody>().velocity = mainCamera.transform.forward * arrowForce;
            Object.Destroy(arrow, deleteTime);
        }
    }
}