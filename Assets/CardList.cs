using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour {

    public List<Sprite> gearSlots = new List<Sprite>();

    public GameObject spellCard;
    public GameObject consumableCard;
    public GameObject followerCard;
    public GameObject gearCard;
    public GameObject enemyCard;

    public List<Card> Consumables = new List<Card>();
    public List<Card> Gear = new List<Card>();
    public List<Card> Followers = new List<Card>();
    public List<Card> Spells = new List<Card>();
    public List<Card> Enemies = new List<Card>();
    
    GameObject selectedTarget;

    public void CardActivation(string cardName, GameObject target)
    {
        StartCoroutine(GetInformation(cardName, target));
    }

    public void EquipArmor(Card card, GameObject targetPlayer)
    {
        PlayerScript targetedPlayer = targetPlayer.transform.parent.GetComponent<PlayerScript>();
        GameObject targetedPlayerGearDeck = targetedPlayer.transform.GetChild(0).GetChild(1).gameObject;
        targetedPlayer.gearCards.Remove(card);
        switch (card.cardslot)
        {
            case (Card.cardSlot.Head):
                if (targetedPlayer.head != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.head);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.head);
                }
                targetedPlayer.head = card;
                break;
            case (Card.cardSlot.Body):
                if (targetedPlayer.chest != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.chest);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.chest);
                }
                targetedPlayer.chest = card;
                break;
            case (Card.cardSlot.Legs):
                if (targetedPlayer.legs != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.legs);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.legs);
                }
                targetedPlayer.legs = card;
                break;
            case (Card.cardSlot.Boots):
                if (targetedPlayer.feet != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.feet);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.feet);
                }
                targetedPlayer.feet = card;
                break;
            case (Card.cardSlot.Main_Hand):
                if (targetedPlayer.mainHand != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.mainHand);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.mainHand);
                }
                targetedPlayer.mainHand = card;
                break;
            case (Card.cardSlot.Off_Hand):
                if (targetedPlayer.offHand != null)
                {
                    targetedPlayer.gearCards.Add(targetedPlayer.offHand);
                    var addedGear = Instantiate(gearCard, targetedPlayerGearDeck.transform);
                    addedGear.GetComponent<RenderCard>().Render(targetedPlayer.offHand);
                }
                targetedPlayer.offHand = card;
                break;
            case (Card.cardSlot.Two_Hand):
                break;
        }
    }

    IEnumerator GetInformation(string cardName, GameObject target)
    {
        selectedTarget = target;
        yield return new WaitForEndOfFrame();
        Invoke(cardName, 0);
    }

    void Fireball()
    {
        RenderCard script = selectedTarget.GetComponent<RenderCard>();
        script.thisCard.cardHealth -= 1;
        script.UpdateCard();
    }

    void Heal()
    {
        RenderCard script = selectedTarget.GetComponent<RenderCard>();
        script.thisCard.cardHealth += 4;
        script.UpdateCard();
    }

}
