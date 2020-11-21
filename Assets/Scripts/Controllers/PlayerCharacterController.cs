using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : BaseCharacterController
{
    public Player player;

    public void InitializeNewCharacter(Player player)
    {
        this.player = player;
        transform.position = player.position;
        GameManager.instance.canvasController.UpdateExperienceAndLevel(player.experience, player.level);
        CalculateMaxHealthAndMaxMana();
        player.health = maxHealth;
        player.mana = maxMana;
        health = maxHealth;
        mana = maxMana;
        SetMaxHealthAndMaxMana(maxHealth, maxMana);
    }

    private void Update()
    {
        if (player.position != transform.position)
        {
            player.position = transform.position;
        }
    }

    public void InitializeLoadedCharacter(Player player)
    {
        transform.position = player.position;
    }

    public void UpdateFromLevelUp(Player player)
    {
        this.player = player;
        CalculateMaxHealthAndMaxMana();
        player.health = maxHealth;
        player.mana = maxMana;
        health = maxHealth;
        mana = maxMana;

        SetMaxHealthAndMaxMana(maxHealth, maxMana);
    }

    public void IncreaseExperience(int experience)
    {
        player.experience += experience;
        if (experience > 5 * player.level)
        {
            LevelUp();
        }
        GameManager.instance.canvasController.UpdateExperienceAndLevel(player.experience, player.level);
    }

    public void LevelUp()
    {
        player.level++;
        GameManager.instance.canvasController.UpdateExperienceAndLevel(player.experience, player.level);
        ViewManager.instance.ChangeToLevelUp(player);
    }

    public void CalculateMaxHealthAndMaxMana()
    {
        maxHealth = 10 + Mathf.RoundToInt(player.constitution / 6)
           + Mathf.RoundToInt(player.strength / 12);
        maxMana = 5 + Mathf.RoundToInt(player.intelligence / 12)
            + Mathf.RoundToInt(player.wisdom / 18);
    }

    public override void ChangeHealth(int change)
    {
        base.ChangeHealth(change);
        player.health = health;
    }

    public override void ChangeMana(int change)
    {
        base.ChangeMana(change);
        player.mana = mana;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("transition"))
        {
            GameManager.instance.cameraController.ChangePositions();
        }
    }
}
