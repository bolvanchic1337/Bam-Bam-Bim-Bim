using UnityEngine;
public class bulletDamage : MonoBehaviour
{
    public PlayerStats stats;
    public JudgmentDay state;
    public Bullet b;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
            if (state.valueMax == stats.inteligence && state.valueMax != stats.agillity)
            {
                EnemyStats.Damage("magical", stats.attack);
                Destroy(gameObject);
            }
            else if (state.valueMax == stats.agillity && state.valueMax != stats.strength && state.valueMax != stats.inteligence)
            {
                EnemyStats.Damage("pure", stats.attack);
                Destroy(gameObject);
            }
            else if (state.valueMax == stats.strength && state.valueMax != stats.agillity)
            {
                EnemyStats.Damage("physical", stats.attack);
                Destroy(gameObject);
            }
            else if (stats.agillity == state.valueMax && stats.inteligence == state.valueMax && stats.strength == state.valueMax)
            {
                EnemyStats.Damage("pure", stats.attack);
                Destroy(gameObject);
            }
            else
            {
                EnemyStats.Damage("physical", stats.attack);
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Block"))
        {
            Destroy(b.m_bullet);
        }
    }
}