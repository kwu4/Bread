using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIController : MonoBehaviour
{
    public Text strengthAmountText, intAmountText, wisAmountText,
        conAmountText, dexAmountText, pointsLeftText, warningText, nameText;
    public int initialPoints, strength, intelligence, wis, con, dex;
    private int pointsLeft;
    private Player player;

    public void Initialize(Player player)
    {
        pointsLeft = 5;
        this.player = player;
        strength = player.strength;
        intelligence = player.intelligence;
        wis = player.wisdom;
        con = player.constitution;
        dex = player.dexterity;
        UpdatePointsLeftText(0);
        nameText.text = player.playerName;
    }

    private void UpdatePointsLeftText(int change)
    {
        pointsLeft += -change;
        if (pointsLeft < 0) return;
        pointsLeftText.text = "Points Left: " + pointsLeft.ToString();
        strengthAmountText.text = strength.ToString();
        dexAmountText.text = dex.ToString();
        intAmountText.text = intelligence.ToString();
        wisAmountText.text = wis.ToString();
        conAmountText.text = con.ToString();
    }

    public void ChangeStrength(int change)
    {
        if (strength <= player.strength && change == -1 || pointsLeft <= 0) return;
        player.strength += change;
        strength += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeInt(int change)
    {
        if (intelligence <= player.intelligence && change == -1 || pointsLeft <= 0) return;
        intelligence += change;
        player.intelligence += change;

        UpdatePointsLeftText(change);
    }

    public void ChangeWis(int change)
    {
        if (wis <= player.wisdom && change == -1 || pointsLeft <= 0) return;
        wis += change;
        player.wisdom += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeCon(int change)
    {
        if (con <= player.constitution && change == -1 || pointsLeft <= 0) return;
        con += change;
        player.constitution += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeDex(int change)
    {
        if (dex <= player.dexterity && change == -1 || pointsLeft <= 0) return;
        dex += change;
        player.dexterity += change;
        UpdatePointsLeftText(change);
    }

    public void LevelUp()
    {
        if (pointsLeft > 0)
        {
            StartCoroutine(TemporaryWarningText("Please assign all points to your character"));
            return;
        }
        GameManager.instance.UpdatePlayer(player);
        ViewManager.instance.ChangeToGameplay();
    }

    private IEnumerator TemporaryWarningText(string text)
    {
        warningText.text = text;
        yield return new WaitForSeconds(3);
        warningText.text = "";
    }
}
