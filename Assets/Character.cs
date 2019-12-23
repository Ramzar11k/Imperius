using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game Items/Character", order = 0)]
public class Character : ScriptableObject{

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
}
