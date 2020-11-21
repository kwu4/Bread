

using UnityEngine;
using UnityEngine.UI;

public class SaveGameContainerController : MonoBehaviour
{
    public Text playerNameText, manaText, healthText, levelText;
    private Player player;
    private Button button;

    public void Initialize(Player player)
    {
        this.player = player;
        playerNameText.text = string.Format("Name: {0}", player.playerName);
        manaText.text = string.Format("Strength: {0}", player.strength.ToString());
        healthText.text = string.Format("Intelligence: {0}", player.intelligence.ToString());
        levelText.text = string.Format("Level: {0}", player.level.ToString());
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            GameManager.instance.ChooseSave(player);
        });
    }
}
