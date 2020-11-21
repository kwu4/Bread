using UnityEngine;

public class Player
{
    public string playerName;
    public int health, mana, level, experience;
    public int strength, intelligence, wisdom, dexterity, constitution;
    public Vector3 position;
    public int currentLevel;

    public Player(string playerName, int health, int mana, int level,
        int experience, int strength, int intelligence,
        int wisdom, int dexterity, int constitution,
        Vector3 position, int currentLevel)
    {
        this.playerName = playerName;
        this.health = health;
        this.mana = mana;
        this.level = level;
        this.experience = experience;
        this.strength = strength;
        this.intelligence = intelligence;
        this.wisdom = wisdom;
        this.dexterity = dexterity;
        this.constitution = constitution;
        this.position = position;
        this.currentLevel = currentLevel;
    }
}
