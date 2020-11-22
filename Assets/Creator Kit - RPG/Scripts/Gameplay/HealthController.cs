using RPGM.Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject healthBar;
    public List<GameObject> hearts;
    public Sprite sprite;
    public PlayerStats playerStats;

    private static ILogger logger = Debug.unityLogger;
    void Start()
    {

        playerStats.onHealthChangedCallback = updateHealth;
        hearts = new List<GameObject>();

        for (int i = 0; i < playerStats.MaxHealth; i++)
        {
            GameObject heart = new GameObject();
            SpriteRenderer renderer = heart.AddComponent<SpriteRenderer>();
            RectTransform rectTransform = heart.AddComponent<RectTransform>();
            rectTransform.SetParent(healthBar.transform);
            heart.transform.localPosition = new Vector3((float)(-2 + .6 * i), 0, 0);
            renderer.sprite = sprite;
            hearts.Add(heart);
        }

        updateHealth();
    }

    void updateHealth()
    {
        logger.Log(playerStats.Health);
        for (int i = 0; i < playerStats.Health && i < playerStats.MaxHealth; i++)
        {
            hearts[i].SetActive(true);
        }

        for (int i = playerStats.Health; i < playerStats.MaxHealth; i++)
        {
            hearts[i].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
