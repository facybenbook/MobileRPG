﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Levelling up class 
 * 
 */
public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;

    public int[] ExpNeededToLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    public int currentHp;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {
        currentHp = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (currentExp >= ExpNeededToLevelUp[currentLevel])
        {
            //currentLevel++;
            LevelUp();
        }
	}

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;

        thePlayerHealth.playerMaxHealth = currentHp;
        thePlayerHealth.playerCurrentHealth += currentHp - HPLevels[currentLevel - 1];

        currentHp = HPLevels[currentLevel];
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }
}
