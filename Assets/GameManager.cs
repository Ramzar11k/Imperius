using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerScript player;
    public List<PlayerScript> players = new List<PlayerScript>();
    public CardList cardList;
    public Card highLightedCard;
    public GameObject playersObject;
    public GameObject enemiesObject;

    public enum GamePhase { GameStart, Upkeep, PlayerTurn, EnemyTurn, EventPhase, EndTurn}
    public GamePhase turnState;

    GameObject mainCanvas;

	void Start ()
    {
        turnState = GamePhase.GameStart;
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        playersObject = GameObject.FindGameObjectWithTag("PlayersObject");
        enemiesObject = GameObject.FindGameObjectWithTag("EnemiesObject");
        for (var i = 0; i < playersObject.transform.childCount; i++)
            players.Add(playersObject.transform.GetChild(i).GetComponent<PlayerScript>());
    }
	void Update () {
        HighlightCard();
        AdvanceTurn();
    }
    public void AddSpell()
    {
        int temp = Random.Range(0, cardList.Spells.Count);
        player.spellCards.Add(cardList.Spells[temp]);
        var addedSpell = Instantiate(cardList.spellCard, player.cardDeck.transform.GetChild(0));
        addedSpell.GetComponent<RenderCard>().Render(cardList.Spells[temp]);
    }
    public void AddGear()
    {
        int temp = Random.Range(0, cardList.Gear.Count);
        player.gearCards.Add(cardList.Gear[temp]);
        var addedSpell = Instantiate(cardList.gearCard, player.cardDeck.transform.GetChild(1));
        addedSpell.GetComponent<RenderCard>().Render(cardList.Gear[temp]);
    }
    public void AddFollower()
    {
        int temp = Random.Range(0, cardList.Followers.Count);
        player.followerCards.Add(cardList.Followers[temp]);
        var addedFollower = Instantiate(cardList.followerCard, player.cardDeck.transform.GetChild(2));
        addedFollower.GetComponent<RenderCard>().Render(cardList.Followers[temp]);
    }
    public void AddConsumable()
    {
        int temp = Random.Range(0, cardList.Consumables.Count);
        player.itemCards.Add(cardList.Consumables[temp]);
        var addedConsumable = Instantiate(cardList.consumableCard, player.cardDeck.transform.GetChild(3));
        addedConsumable.GetComponent<RenderCard>().Render(cardList.Consumables[temp]);
    }
    public void HighlightCard()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<RenderCard>() != null)
            {
                if (highLightedCard != hit.transform.gameObject.GetComponent<RenderCard>().card)
                {
                    highLightedCard = hit.transform.gameObject.GetComponent<RenderCard>().card;
                    if (highLightedCard.cardtype == Card.cardType.Enemy)
                    {
                        var card = Instantiate(hit.transform.GetChild(0), mainCanvas.transform.GetChild(0));
                        card.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                        for (var i = 8; i < hit.transform.GetChild(0).childCount; i++)
                            card.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    else
                    {
                        var card = Instantiate(hit.transform.GetChild(0), mainCanvas.transform.GetChild(0));
                        card.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    }
                    if (player.transform.GetChild(0).GetChild(0).childCount > 1)
                        Destroy(mainCanvas.transform.GetChild(0).GetChild(0).gameObject);
                }
            }
            else
            {
                highLightedCard = null;
                if (mainCanvas.transform.GetChild(0).childCount > 0)
                    Destroy(mainCanvas.transform.GetChild(0).GetChild(0).gameObject);
            }

        }
    }
    public void AdvanceTurn()
    {
        if (turnState == GamePhase.Upkeep)
        {
            foreach (Transform player in playersObject.transform)
            {
                player.GetComponent<PlayerScript>().actions = 2;
            }
            turnState = GamePhase.PlayerTurn;
        }
        if (turnState == GamePhase.PlayerTurn)
        {
            foreach (Transform player in playersObject.transform)
            {
                if (player.GetComponent<PlayerScript>().actions > 0)
                    return;
            }
            turnState = GamePhase.EnemyTurn;
        }
        if (turnState == GamePhase.EnemyTurn)
        {
            turnState = GamePhase.EventPhase;
        }
        if (turnState == GamePhase.EventPhase)
        {
            turnState = GamePhase.EndTurn;
        }
        if (turnState == GamePhase.EndTurn)
        {
            turnState = GamePhase.Upkeep;
        }
    }
}
