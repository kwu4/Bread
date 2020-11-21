using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameUIController : MonoBehaviour {

    public Transform organizer;
    public GameObject saveGameContainer;
    
	public void Initialize(List<Player> players)
    {
        foreach(Transform child in organizer)
        {
            Destroy(child.gameObject);
        }

        foreach(Player player in players)
        {
            GameObject saveGame = Instantiate(saveGameContainer, organizer);
            saveGame.GetComponent<SaveGameContainerController>().Initialize(player);
        }
        
        GameManager.instance.ChooseSave(null);
    }

    public void LoadGame()
    {
        GameManager.instance.LoadChosenSave();
    }

    public void DeleteChosenSave()
    {
        GameManager.instance.DeleteChosenSave();
    }
}
