using UnityEngine;
using Pathfinding;
using System.Collections;
public class AmberStriker : MonoBehaviour
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
    public Rigidbody2D rb;
    public GameObject o;
    public Transform pos;
    public float dice;
    public float f;
    public float dashTime = 3;
    private float dashCurTime =3;
    private void OnEnable()
    {
        stat.mana = stat.maxMana;
    }
    private void Awake()
    {
        Dice();
    }
    void Update()
    {
        aIPath.maxSpeed = movement.runSpeed;
        dice -= Time.deltaTime;
        dashTime-=Time.deltaTime;
        float dist = Vector3.Distance(player.position, transform.position);
        if (transform.position.y<=100)
        {
        transform.position = new Vector2(transform.position.x,player.position.y);
        }
        if (bullet.m_bullet != null)
        {
            float bulletDist = Vector3.Distance(bullet.m_bullet.transform.position, transform.position);
            if (bulletDist < 7)
            {
                animator.SetTrigger("attack");                
            }
        }
        if (dist < 5)
        {
            animator.SetTrigger("attack");
        }
        switch (dice <= 0 && stat.mana >= 2)
        {
            case true:
                stat.mana -= 2;
                Shoot();
                break;
        }
        switch (dice <= 0)
        {
            case true:
                Dice();
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = bullet.stats;
            float objects = Vector3.Distance(other.gameObject.transform.position, transform.position);
            if (objects < 5)
            {
                animator.SetTrigger("attack");
            }
        }
    }
        private void Shoot()
    {
        animator.SetTrigger("shoot");
        StartCoroutine(Shot());
        Dice();
    }
    private void Dice()
    {
        dice = Random.Range(3, 7);
    }
    private IEnumerator Shot()
    {
        yield return new WaitForSeconds(1);
        GameObject m_bullet = Instantiate(o, pos.position, Quaternion.identity);
        Rigidbody2D rb2 = m_bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(pos.up * f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        stat.mana -= 1;
        if (transform.position.x <= player.transform.position.x)
        {
            transform.position = new Vector2(transform.position.x + 4, transform.position.y);
        }
        else if (transform.position.x > player.transform.position.x)
        {
            transform.position = new Vector2(transform.position.x - 4, transform.position.y);
        }
        yield return new WaitForSeconds(0.2f);
        dashTime = dashCurTime;
    }
}