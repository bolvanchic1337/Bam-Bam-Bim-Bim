using UnityEngine;
public class bulletAS : MonoBehaviour
{
    public objectsStats stats;
    public string damageType;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
            EnemyStats.Damage(damageType, 2);
            EnemyStats.instance = stats;
            Destroy(gameObject);
            stats.mana++;
        }
        else if (other.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}