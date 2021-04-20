using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChain : MonoBehaviour {
    public const string NAME_PLAYER = "player";
    public const string NAME_SABERTOOTH = "sabertooth";
    public const string NAME_SLOTH = "sloth";
    public const string NAME_PLANT = "plant";

    // predators
    private Dictionary<String, HashSet<String>> threats = new Dictionary<string, HashSet<string>>();

    // preys
    private Dictionary<String, HashSet<String>> foods = new Dictionary<string, HashSet<string>>();

    public void Awake() {
        // Create the food chain
        addToChain(NAME_PLAYER,NAME_SABERTOOTH);
        addToChain(NAME_PLAYER, NAME_SLOTH);
        addToChain(NAME_PLAYER, NAME_PLANT);
        addToChain(NAME_SABERTOOTH, NAME_PLAYER);
        addToChain(NAME_SABERTOOTH, NAME_SABERTOOTH);
        addToChain(NAME_SABERTOOTH, NAME_SLOTH);
        // addToChain(NAME_LIZARD, NAME_PLANT);
        addToChain(NAME_SLOTH, NAME_PLANT);
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
    
    public HashSet<String> GetThreat(String name) {
        return threats[name];
    }

}
