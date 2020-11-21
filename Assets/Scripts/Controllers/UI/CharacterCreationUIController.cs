using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationUIController : MonoBehaviour
{
    public Text strengthAmountText, intAmountText, wisAmountText,
        conAmountText, dexAmountText, pointsLeftText, warningText;
    public int initialPoints, strength, intelligence, wis, con, dex;
    private int pointsLeft;
    public InputField nameInputField;

    private void Start()
    {
        UpdatePointsLeftText(-15);
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
        if (strength <= 5 && change == -1 || pointsLeft <= 0) return;
        strength += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeInt(int change)
    {
        if (intelligence <= 5 && change == -1 || pointsLeft <= 0) return;
        intelligence += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeWis(int change)
    {
        if (wis <= 5 && change == -1 || pointsLeft <= 0) return;
        wis += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeCon(int change)
    {
        if (con <= 5 && change == -1 || pointsLeft <= 0) return;
        con += change;
        UpdatePointsLeftText(change);
    }

    public void ChangeDex(int change)
    {
        if (dex <= 5 && change == -1 || pointsLeft <= 0) return;
        dex += change;
        UpdatePointsLeftText(change);
    }

    public void Create()
    {
        if (string.IsNullOrEmpty(nameInputField.text))
        {
            StartCoroutine(TemporaryWarningText("Please input a name for your character"));
            return;
        }
        else if (pointsLeft > 0)
        {
            StartCoroutine(TemporaryWarningText("Please assign all points to your character"));
            return;
        }

        Player player = new Player(nameInputField.text, 0, 0, 1, 0,
            strength, intelligence, wis, dex, con, Vector3.zero, 0);
        GameManager.instance.CreateNewPlayer(player);
        ViewManager.instance.ChangeToGameplay();
    }

    private IEnumerator TemporaryWarningText(string text)
    {
        warningText.text = text;
        yield return new WaitForSeconds(3);
        warningText.text = "";
    }
}
