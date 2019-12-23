using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterConstructor
{
    public string characterName;
    public string characterDescription;
    public string characterAbility;
    public int characterHealth;
    public int characterArmor;
    public int characterMana;
    public int characterStrenght;
    public int characterIntellect;
    public int characterAgility;
    public int characterConstitution;
    public int characterCharisma;
    public int characterPerception;
    public Sprite characterArt;
    public GameObject characterModel;

    public CharacterConstructor(Character character)
    {
        this.characterName = character.characterName;
        this.characterDescription = character.characterDescription;
        this.characterAbility = character.characterAbility;
        this.characterHealth = character.characterHealth;
        this.characterArmor = character.characterArmor;
        this.characterMana = character.characterMana;
        this.characterStrenght = character.characterStrenght;
        this.characterIntellect = character.characterIntellect;
        this.characterAgility = character.characterAgility;
        this.characterConstitution = character.characterConstitution;
        this.characterCharisma = character.characterCharisma;
        this.characterPerception = character.characterPerception;
        this.characterArt = character.characterArt;
        this.characterModel = character.characterModel;
    }
}
