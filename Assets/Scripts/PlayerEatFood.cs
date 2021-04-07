using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEatFood : MonoBehaviour {
    private Stats stats;

    // Raycast info
    private float thickness = 1f; // thickness/radius of the raycast
    private Vector3 origin;
    private Vector3 direction;
    private float maxDistance = 2.5f; // max distance that the ray can go
    public LayerMask layerMask; // life layer
    public GameObject foodParticles;
    private bool currentUIStatus = true; // true is showing. should toggle off instantly in the update method

    public Text interactUI;

    private void Awake() {
        stats = GetComponent<Stats>();

        layerMask = LayerMask.GetMask("Life");
        interactUI = GameObject.Find("Text_E").GetComponent<Text>();
    }

    private void toggleUI(bool isActive) {
        if (isActive != currentUIStatus) {
            interactUI.enabled = isActive;
            currentUIStatus = isActive;
        }
    }

    // Update is called once per frame
    void Update() {
        direction = Camera.main.transform.forward;
        origin = Camera.main.transform.position;
        RaycastHit hit;
        if (Physics.SphereCast(origin, thickness, direction, out hit, maxDistance, layerMask)) {
            // NOTE : WILL NOT WORK IF THE FOOD IS NOT ON THE ROOT
            // Debug.Log(hit.transform.root.gameObject.name);
            // interact with it
            // press E to eat

            // var root = hit.transform.root;
            // interactUI.gameObject.transform.position = root.position + root.up.normalized * 0.5f;
            // interactUI.gameObject.transform.forward = Camera.main.transform.forward;
            if (hit.transform.root.GetComponent<FoodStats>().isReadyToEat) {
                toggleUI(true);

                if (Input.GetKeyDown(KeyCode.E)) {
                    stats.AddFoodAmount(hit.transform.root.GetComponent<FoodStats>().foodAmount);
                    hit.transform.root.GetComponent<FoodStats>().SpawnFoodParticles(hit.transform.position, hit.transform.rotation);
                    hit.transform.root.GetComponent<FoodStats>().DepleteTotalFoodAmount();
                }
            }
        }
        else {
            toggleUI(false);
        }
    }
}