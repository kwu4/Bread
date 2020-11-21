
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private List<Player> savedGames = new List<Player>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one DatabaseManager");
        }
    }

    public void SaveGame(Player player)
    {
        string saveData = JsonUtility.ToJson(player);
        File.WriteAllText(Application.dataPath + string.Format("/Resources/Saves/{0}", player.playerName + ".json"), saveData);
    }

    public void CheckSaves(System.Action<List<Player>> callback)
    {
        List<Player> players = new List<Player>();

        if (Directory.Exists(Application.dataPath + "/Resources/Saves"))
        {
            foreach (string file in
                Directory.GetFiles(Application.dataPath + "/Resources/Saves"))
            {
                if (file.EndsWith("meta")) continue;

                string json = File.ReadAllText(file);
                Player p = JsonUtility.FromJson<Player>(json);
                players.Add(p);
            }
        }
        callback(players);
    }

    public void DeleteSave(string playerName, System.Action<bool> callback)
    {
        if (File.Exists(Application.dataPath
            + string.Format("/Resources/Saves/{0}",
            playerName + ".json")))
        {
            File.Delete(Application.dataPath
            + string.Format("/Resources/Saves/{0}",
            playerName + ".json"));
            callback(!File.Exists(Application.dataPath
            + string.Format("/Resources/Saves/{0}",
            playerName + ".json")));
            return;
        }

        callback(false);
    }
}
