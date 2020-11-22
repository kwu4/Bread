using RPGM.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    public PlayerStats playerStats;

    void Start()
    {
        playerStats = PlayerStats.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.Health == 3)
        {
            health1.active = true;
            health2.active = true;
            health3.active = true;
        }
        else if (playerStats.Health == 2)
        {
            health1.active = true;
            health2.active = true;
            health3.active = false;

        }
        else if (playerStats.Health == 1)
        {
            health1.active = true;
            health2.active = false;
            health3.active = false;

        }
        else if (playerStats.Health == 0)
        {
            health1.active = false;
            health2.active = false;
            health3.active = false;
        }
    }
}
