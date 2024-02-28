using UnityEngine;
using Pathfinding;
public class newStalker : MonoBehaviour
{
    public AIPath aIPath;
    public PlayerStats stats;
    public bool a;
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        switch (aIPath.desiredVelocity.x>= 0.01f)
        {
            case true:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case false:
                break;
        }
        switch (aIPath.desiredVelocity.x <= -0.01f)
        {
            case true:
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent(out PlayerStats EnemyStats))
        {
            if(a)
            {
                stats.mana++;
                EnemyStats.mana--;
            }
            else if (!a && EnemyStats.money > 0)
            {
                EnemyStats.money--;
            }
        }
    }
}