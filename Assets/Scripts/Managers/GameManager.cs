using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerCharacterController characterController;
    public GameplayCanvasController canvasController;
    public static GameManager instance;
    private Player chosenSave;
    public CameraController cameraController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one GameManager");
        }
    }

    public void CreateNewPlayer(Player player)
    {
        GameObject playerObject = Instantiate(playerPrefab, null);
        characterController = playerObject.GetComponent<PlayerCharacterController>();
        characterController.InitializeNewCharacter(player);
    }

    internal void DeleteChosenSave()
    {
        if (chosenSave == null) return;
        DatabaseManager.instance.DeleteSave(chosenSave.playerName, (success)=>
        {
            if (success)
            {
                CallCheckLoad();
                chosenSave = null;
            }
        });
    }

    internal void LoadChosenSave()
    {
        if (chosenSave == null) return;
        if (characterController != null) Destroy(characterController.gameObject);
        CreateNewPlayer(chosenSave);
        ViewManager.instance.ChangeToGameplay();
    }

    public void UpdatePlayer(Player player)
    {
        characterController.UpdateFromLevelUp(player);
    }

    public void CallSave()
    {
        DatabaseManager.instance.SaveGame(characterController.player);
    }

    public void CallCheckLoad()
    {
        DatabaseManager.instance.CheckSaves((players) =>
        {
            ViewManager.instance.ChangeToLoad(players);
        });
    }

    public void ChooseSave(Player player)
    {
        chosenSave = player;
    }

    public void ChangeHealth(int health)
    {
        characterController.ChangeHealth(health);
    }

    public void ChangeMana(int mana)
    {
        characterController.ChangeMana(mana);
    }

    public void IncreaseExperience(int experience)
    {
        if (characterController == null) return;
        characterController.IncreaseExperience(experience);
    }

}
