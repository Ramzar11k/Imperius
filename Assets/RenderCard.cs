using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderCard : MonoBehaviour
{

    public CardList cardList;
    public Card card;
    public CardConstructor thisCard;

    private void Awake()
    {
        cardList = GameObject.FindGameObjectWithTag("CardList").GetComponent<CardList>();
        if (card != null)
        {
            Render(card);
        }
    }
    private void Start()
    {
            RenderModel();
    }
    private void Update()
    {
    }
    public void Render(Card card1)
    {
        card = card1;
        thisCard = new CardConstructor(card);

        name = card.name;
        switch (card.cardtype)
        {
            case Card.cardType.Spell:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardManaCost.ToString();
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Image>().sprite = thisCard.cardArt;
                break;
            case Card.cardType.Gear:
                switch (card.cardslot)
                {
                    case (Card.cardSlot.Head):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[0];
                        break;
                    case (Card.cardSlot.Body):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[1];
                        break;
                    case (Card.cardSlot.Legs):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[2];
                        break;
                    case (Card.cardSlot.Boots):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[3];
                        break;
                    case (Card.cardSlot.Main_Hand):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[4];
                        break;
                    case (Card.cardSlot.Off_Hand):
                        transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>().sprite = cardList.gearSlots[5];
                        break;
                }
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardMana.ToString();
                if (card.cardArmor != 0)
                    transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                break;
            case Card.cardType.Consumable:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                break;
            case Card.cardType.Follower:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>().text = thisCard.cardAttack.ToString();
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                if (card.cardArmor != 0)
                    transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                break;
            case Card.cardType.Enemy:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription.Split(';')[0];
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardMovement.ToString();
                transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(10).GetComponent<Text>().text = thisCard.cardAttack.ToString();
                transform.GetChild(0).GetChild(0).GetChild(11).GetComponent<Text>().text = thisCard.cardDescription.Split(';')[1];
                transform.GetChild(0).GetChild(0).GetChild(12).GetComponent<Image>().sprite = thisCard.cardArt;
                if (card.cardArmor != 0)
                {
                    transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                    transform.GetChild(0).GetChild(0).GetChild(9).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                }
                break;
        }
    }
    IEnumerator UpdatePosition(Transform deck)
    {
        transform.SetParent(null);
        yield return new WaitForEndOfFrame();
        foreach (Transform child in deck)
        {
            child.position = new Vector3(deck.position.x + child.GetSiblingIndex(), deck.position.y, deck.position.z - (float)(child.GetSiblingIndex()) * 0.001f);
        }
        Destroy(gameObject);
    }
    public void UpdateCard()
    {
        switch (card.cardtype)
        {
            case Card.cardType.Spell:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardManaCost.ToString();
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Image>().sprite = thisCard.cardArt;
                break;
            case Card.cardType.Gear:
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardMana.ToString();
                if (card.cardArmor != 0)
                    transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                break;
            case Card.cardType.Consumable:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                break;
            case Card.cardType.Follower:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription;
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>().text = thisCard.cardAttack.ToString();
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                if (card.cardArmor != 0)
                    transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                break;
            case Card.cardType.Enemy:
                transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = thisCard.cardName;
                transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>().text = thisCard.cardDescription.Split(';')[0];
                transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Image>().sprite = thisCard.cardArt;
                transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<Text>().text = thisCard.cardMovement.ToString();
                transform.GetChild(0).GetChild(0).GetChild(8).GetComponent<Text>().text = thisCard.cardHealth.ToString();
                transform.GetChild(0).GetChild(0).GetChild(10).GetComponent<Text>().text = thisCard.cardAttack.ToString();
                transform.GetChild(0).GetChild(0).GetChild(11).GetComponent<Text>().text = thisCard.cardDescription.Split(';')[1];
                transform.GetChild(0).GetChild(0).GetChild(12).GetComponent<Image>().sprite = thisCard.cardArt;
                if (card.cardArmor != 0)
                {
                    transform.GetChild(0).GetChild(0).GetChild(7).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                    transform.GetChild(0).GetChild(0).GetChild(9).GetComponent<Text>().text = thisCard.cardArmor.ToString();
                }
                break;
        }
    }

    public void RenderModel()
    {
        if (thisCard.cardModel != null)
            Instantiate(thisCard.cardModel, transform.GetChild(1));
    }
}
