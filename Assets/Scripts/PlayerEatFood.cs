using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEatFood : MonoBehaviour {
    private Stats stats;

    // Raycast info
    private float thickness = 1f; // thickness/radius of the raycast
    private Vector3 origin;
    private Vector3 direction;
    private float maxDistance = 2.5f; // max distance that the ray can go
    public LayerMask layerMask; // life layer


    private void Awake() {
        stats = GetComponent<Stats>();
        
        layerMask = LayerMask.GetMask("Life");
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
            if (Input.GetKeyDown(KeyCode.E)) {
                stats.AddFoodAmount(hit.transform.root.GetComponent<FoodStats>().foodAmount);
                hit.transform.root.GetComponent<FoodStats>().DepleteTotalFoodAmount();
            }
        }
    }
}