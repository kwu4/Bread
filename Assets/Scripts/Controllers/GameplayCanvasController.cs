using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvasController : MonoBehaviour
{
    public Text healthText, manaText, experienceText, levelText;

    public void UpdateHealthAndMana(int health, int mana)
    {
        healthText.text = string.Format("Health: {0}", health.ToString());
        manaText.text = string.Format("Mana: {0}", mana.ToString());
    }

    public void UpdateExperienceAndLevel(int experience, int level)
    {
        if (experienceText == null) return;
        experienceText.text = string.Format("Experience: {0}", experience.ToString());
        levelText.text = string.Format("Level: {0}", level.ToString());
    }
}
