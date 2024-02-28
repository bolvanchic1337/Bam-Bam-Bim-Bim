using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    public objectsStats stats;
    public string damageType;
    public Transform pos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
            EnemyStats.Damage(damageType, stats.attack);
            EnemyStats.instance = stats;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}