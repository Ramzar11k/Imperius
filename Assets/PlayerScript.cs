using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Character character;
    public CharacterConstructor thisCharacter;
    public List<Card> spellCards = new List<Card>();
    public List<Card> itemCards = new List<Card>();
    public List<Card> followerCards = new List<Card>();
    public List<Card> gearCards = new List<Card>();

    public GameObject cardDeck;
    public GameObject characterSheet;

    public Card head;
    public Card chest;
    public Card legs;
    public Card feet;
    public Card mainHand;
    public Card offHand;

    public CharacterScript characterScript;

    public int actions = 2;
	void Start ()
    {
        GetCharacter();
        ConstructCharacter();
        cardDeck = transform.GetChild(0).gameObject;
        characterSheet = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        ShowGearIcons();
        if (Input.GetKeyDown(KeyCode.D))
            actions--;
	}

    private void OnMouseOver()
    {

    }

    void ShowGearIcons()
    {
        if (head != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        if (chest != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        if (legs != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);
        if (feet != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(false);
        if (mainHand != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(5).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(5).gameObject.SetActive(false);
        if (offHand != null)
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(6).gameObject.SetActive(true);
        else
            characterSheet.transform.GetChild(0).GetChild(0).GetChild(6).gameObject.SetActive(false);
    }

    void GetCharacter()
    {
        characterScript = transform.GetChild(2).GetChild(0).GetComponent<CharacterScript>();
    }

    void ConstructCharacter()
    {
        thisCharacter = new CharacterConstructor(character);
    }

}
