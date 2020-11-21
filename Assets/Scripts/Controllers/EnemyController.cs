using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int experience;

    private void OnDestroy()
    {
        GameManager.instance.IncreaseExperience(experience);
    }
}
