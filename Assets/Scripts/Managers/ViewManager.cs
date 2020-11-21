using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public GameObject titleView, mainMenuView,
        gameplayView, loadView, saveView, settingsView,
        optionsView, characterCreationView,
        levelUpView;

    private GameObject lastView, activeView;
    private Player player;
    private List<Player> players = new List<Player>();
    public static ViewManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one ViewManager");
        }
    }

    private void Start()
    {
        ChangeView(View.Title);
    }

    public void ChangeView(View view)
    {
        if (activeView != null) activeView.SetActive(false);
        lastView = activeView;
        activeView = null;
        switch (view)
        {
            case View.Gameplay:
                activeView = gameplayView;
                break;
            case View.MainMenu:
                activeView = mainMenuView;
                break;
            case View.Load:
                activeView = loadView;
                if (activeView == null) break;
                activeView.GetComponent<LoadGameUIController>().Initialize(players);
                break;
            case View.Save:
                activeView = saveView;
                break;
            case View.Settings:
                activeView = settingsView;
                break;
            case View.Title:
                activeView = titleView;
                break;
            case View.Options:
                activeView = optionsView;
                break;
            case View.CharacterCreation:
                activeView = characterCreationView;
                break;
            case View.LevelUp:
                activeView = levelUpView;
                if (activeView == null) break;
                activeView.GetComponent<LevelUpUIController>().Initialize(player);
                break;
        }
        activeView.SetActive(true);
    }

    public void ChangeToMainMenu()
    {
        ChangeView(View.MainMenu);
    }

    public void ChangeToLoad(List<Player> players)
    {
        this.players = players;
        ChangeView(View.Load);
    }

    public void ChangeToSave()
    {
        ChangeView(View.Save);
    }

    public void ChangeToOptions()
    {
        ChangeView(View.Options);
    }

    public void ChangeToGameplay()
    {
        ChangeView(View.Gameplay);
    }

    public void ChangeToSettings()
    {
        ChangeView(View.Settings);
    }

    public void ChangeToCharacterCreation()
    {
        ChangeView(View.CharacterCreation);
    }

    public void ChangeToLevelUp(Player player)
    {
        this.player = player;
        ChangeView(View.LevelUp);
    }

    public void Back()
    {
        GameObject transition = null;
        transition = lastView;
        lastView.SetActive(true);
        activeView.SetActive(false);
        lastView = activeView;
        activeView = transition;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
