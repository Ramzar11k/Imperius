using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardConstructor  
{
   
    public string cardName;
    public string cardDescription;
    public Card.cardType cardtype;
    public Card.cardSlot cardslot;
    public int cardManaCost;
    public int cardHealth;
    public int cardMana;
    public int cardArmor;
    public int cardMovement;
    public int cardAttack;
    public bool cardConsumable;
    public Sprite cardArt;
    public List<bool> validTargets;
    public GameObject cardModel;

    public CardConstructor(Card card)
    {
        this.cardName = card.cardName;
        this.cardDescription = card.cardDescription;
        this.cardtype = card.cardtype;
        this.cardslot = card.cardslot;
        this.cardManaCost = card.cardManaCost;
        this.cardHealth = card.cardHealth;
        this.cardMana = card.cardMana;
        this.cardArmor = card.cardArmor;
        this.cardMovement = card.cardMovement;
        this.cardAttack = card.cardAttack;
        this.cardConsumable = card.cardConsumable;
        this.cardArt = card.cardArt;
        this.validTargets = card.validTargets;
        this.cardConsumable = card.cardConsumable;
        this.cardModel = card.cardModel;
    }
}
