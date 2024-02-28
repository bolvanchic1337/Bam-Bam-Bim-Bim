using UnityEngine;
public class AABulletDamage : MonoBehaviour
{
    public PlayerStats stats;
    public ArcaneArrows arrow;
    public float delay;
    public float a;
    private void OnEnable()
    {
        delay = 0.7f;
        a = 0;
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            a = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
            switch (arrow.active)
            {
                case true:
                    EnemyStats.Damage("magical", stats.attack + arrow.arrows);
                    EnemyStats.Damage("pure", a);
                    Destroy(gameObject);
                    break;
                case false:
                    EnemyStats.Damage("magical", stats.attack);
                    EnemyStats.Damage("pure", a);
                    Destroy(gameObject);
                    break;
            }
        }
        else if (other.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}
