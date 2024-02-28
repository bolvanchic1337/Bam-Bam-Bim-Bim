using UnityEngine;
public class Circle : MonoBehaviour
{
    public PlayerStats stats;
    public float damage =1;
    public float state;
    public bool pure;
    public bool physical;
    public bool magical;
    public CircleCollider2D colider;
    public CircleCollider2D colider1;
    public Animator animator;
    public void Update()
    {
        state = Mathf.Max(stats.inteligence, stats.strength, stats.agillity);
        if (state == stats.inteligence && state != stats.agillity)
        {
            physical = false;
            magical = true;
            pure = false;
            colider.radius = 1.2f;
            colider1.radius = 1.325f;
            animator.SetBool("isFire", false);
        }
        else if (state == stats.strength && state != stats.agillity)
        {
            physical = true;
            magical = false;
            pure = false;
            colider.radius = 1.2f;
            colider1.radius = 1.325f;
            animator.SetBool("isFire", false);
        }
        else if (state == stats.agillity)
        {
            physical = false;
            magical = false;
            pure = true;
            colider.radius = 1.2f;
            colider1.radius = 1.325f;
            animator.SetBool("isFire", false);
        }
        switch (stats.agillity == stats.strength && stats.agillity == stats.inteligence)
        {
            case true:
                physical = false;
                magical = false;
                pure = true;
                colider.radius = 2.1f;
                colider1.radius = 2.225f;
                animator.SetBool("isFire", true);
                break;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
            if(magical)
            {
                EnemyStats.Damage("magical", damage);
            }
            else if(physical)
            {
                EnemyStats.Damage("physical", damage);
            }
            else if(pure)
            {
                EnemyStats.Damage("pure", damage);
            }
        }
        else if (other.CompareTag("Bullet")){
            Destroy(other.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = null;
        }
    }
}