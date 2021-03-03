﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChain : MonoBehaviour {
    public const string NAME_PLAYER = "player";
    public const string NAME_LIZARD = "lizard";
    public const string NAME_FLY = "fly";
    public const string NAME_PLANT = "plant";

    // predators
    private Dictionary<String, HashSet<String>> threats = new Dictionary<string, HashSet<string>>();

    // preys
    private Dictionary<String, HashSet<String>> foods = new Dictionary<string, HashSet<string>>();

    public void Awake() {
        // Create the food chain
        addToChain(NAME_PLAYER,NAME_LIZARD);
        addToChain(NAME_PLAYER, NAME_FLY);
        addToChain(NAME_PLAYER, NAME_PLANT);
        addToChain(NAME_LIZARD, NAME_PLAYER);
        addToChain(NAME_LIZARD, NAME_FLY);
        // addToChain(NAME_LIZARD, NAME_PLANT);
        addToChain(NAME_FLY, NAME_PLANT);
        // Debug.Log(foods);
        // Debug.Log(threats);
        // Debug.Log("Player Threats Count: " + threats[NAME_PLAYER].Count);
    }

    private void addToChain(String threat, String food) {
        //add to predators list and add to prey list
        if (foods.ContainsKey(threat)) {
            foods[threat].Add(food);
        }
        else {
            foods.Add(threat, new HashSet<string>() {food});
        }

        if (threats.ContainsKey(food)) {
            threats[food].Add(threat);
        }
        else {
            threats.Add(food, new HashSet<string>() {threat});
        }
    }

    public HashSet<String> GetFood(String name) {
        // Debug.Log("food name: " + name);
        return foods[name];
    }

}