using UnityEngine;
using Pathfinding;
public class MaceSkelet : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    [SerializeField]
    private AIPath aIPath;
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private PlayerStats stat;
    [SerializeField]
    private AABullet bullet;
    private void Awake()
    {
    }
    void Update()
    {
        aIPath.maxSpeed = movement.runSpeed;
        if (bullet.m_bullet != null)
        {
            float bulletDist = Vector3.Distance(bullet.m_bullet.transform.position, transform.position);
            if (bulletDist < 5)
            {
                animator.SetTrigger("attack");
            }
        }
        switch (player.position.y > transform.position.y + 20)
        {
            case true:
                transform.position = new Vector2(transform.position.x, -1.47f);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = stat;
            float objects = Vector3.Distance(other.gameObject.transform.position, transform.position);
            if (objects < 4.3f)
            {
                animator.SetTrigger("attack");
            }
            stats.strength--;
            stats.hp--;
            stats.maxHp--;
            stat.strength++;
            stat.maxHp++;
            stat.hp++;
        }
    }
}