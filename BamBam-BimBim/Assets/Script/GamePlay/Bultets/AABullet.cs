using UnityEngine;
public class AABullet : MonoBehaviour
{
    public float m_nextFire;
    public float FireRate = 1.5f;
    public float BulletSpeed = 35;
    [HideInInspector]
    public GameObject m_bullet;
    public ArcaneArrows arrow;
    public GameObject bullet;
    private KeyCode trigger = KeyCode.Mouse1;
    public Animator animator;
    public Transform player;
    public PlayerStats stats;
    private void FixedUpdate()
    {
        m_nextFire = m_nextFire + Time.fixedDeltaTime;
        transform.localScale = player.localScale;
        if (Input.GetMouseButton(1) && m_nextFire > FireRate || Input.GetKeyDown(trigger) && m_nextFire > FireRate)
        {
            if (arrow.active)
            {
                arrow.arrows--;
                stats.mana--;
            }
            animator.SetTrigger("Attack");
            m_nextFire = 0;
            m_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            m_bullet.transform.localScale = player.localScale;
            m_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * BulletSpeed, 0f);
            Destroy(m_bullet, 1.6f);
        }
    }
}