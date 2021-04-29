using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChain : MonoBehaviour {
    // references to the tags of the creatures
    public const string NAME_PLAYER     = "player";
    public const string NAME_SABERTOOTH = "sabertooth";
    public const string NAME_SLOTH      = "sloth";
    public const string NAME_PLANT      = "plant";

    /* acting as a two-way dictionary */
    // predators
    private Dictionary<string, HashSet<string>> threats = new Dictionary<string, HashSet<string>>();

    // preys
    private Dictionary<string, HashSet<string>> foods = new Dictionary<string, HashSet<string>>();

    public void Awake() {
        // Create the food chain
        addToChain(NAME_PLAYER, NAME_SABERTOOTH);
        addToChain(NAME_PLAYER, NAME_SLOTH);
        addToChain(NAME_PLAYER, NAME_PLANT);
        addToChain(NAME_SABERTOOTH, NAME_PLAYER);
        addToChain(NAME_SABERTOOTH, NAME_SABERTOOTH);
        addToChain(NAME_SABERTOOTH, NAME_SLOTH);
        addToChain(NAME_SLOTH, NAME_PLANT);
    }

    // adding to the dictionaries
    private void addToChain(String threat, String food) {
        
        /* add to predators list and add to prey list */

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

    // get all the foods for a given creature
    public HashSet<string> GetFood(string name) {
        return foods[name];
    }

    // get all the threats for a given creature
    public HashSet<string> GetThreat(string name) {
        return threats[name];
    }
}