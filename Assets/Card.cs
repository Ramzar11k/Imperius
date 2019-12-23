using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 4)]
public class Card : ScriptableObject {
    public string cardName;
    public string cardDescription;
    public enum cardType { Spell, Gear, Consumable, Follower, Enemy};
    public cardType cardtype;
    public enum cardSlot { None, Head, Body, Legs, Boots, Main_Hand, Off_Hand, Two_Hand };
    public cardSlot cardslot;
    public int cardManaCost;
    public int cardHealth;
    public int cardMana;
    public int cardArmor;
    public int cardMovement;
    public int cardAttack;
    public bool cardConsumable;
    public Sprite cardArt;
    public List<bool> validTargets = new List<bool>() { false, false, false, false, false, false };
    public GameObject cardModel;
}
