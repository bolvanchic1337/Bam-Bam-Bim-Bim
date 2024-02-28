using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float m_nextFire;
    public float FireRate = 2.0f;
    public GameObject bullet;
    public CircleCollider2D colider;
    public float BulletSpeed;
    [HideInInspector]
    public GameObject m_bullet;
    public PlayerStats stats;
    public JudgmentDay state;
    public GameObject balls;
    public Animator animator;
    public Animator a1;
    public bool a;
    private KeyCode trigger;
    private void Start()
    {
        BulletSpeed = 7;
        FireRate = 2.0f;
    }
    private void Update()
    {
        switch (stats.agillity == state.valueMax && stats.inteligence == state.valueMax && stats.strength == state.valueMax)
        {
            case true:
                BulletSpeed = 32;
                break;
            case false:
                BulletSpeed =20;
                break;
        }
    }
        void FixedUpdate()
    {
        m_nextFire = m_nextFire + Time.fixedDeltaTime;
        if (Input.GetMouseButton(1) && m_nextFire > FireRate || Input.GetKeyDown(trigger) && m_nextFire > FireRate)
        {
            animator.SetTrigger("Attack");
            Vector3 m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
            m_mousePosition.z = 0;
            float m_fireAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
            if (m_mousePosition.x > this.transform.position.x)
            {
                m_fireAngle = -m_fireAngle;
            }
            m_nextFire = 0;
            m_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            m_bullet.GetComponent<Rigidbody2D>().velocity = ((m_mousePosition - transform.position).normalized * BulletSpeed);
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle +100);
            switch (stats.agillity == state.valueMax && stats.inteligence == state.valueMax && stats.strength == state.valueMax)
            {
                case true:
                    m_bullet.GetComponent<Animator>().SetBool("balance", true);
                    colider.radius = 0.8f;
                    FireRate = 1.0f;
                    m_bullet.GetComponent<CircleCollider2D>().radius = colider.radius;
                    Destroy(m_bullet, 1);
                    break;
                case false:
                    m_bullet.GetComponent<Animator>().SetBool("balance", false);
                    colider.radius = 0.7f;
                    FireRate = 2.0f;
                    m_bullet.GetComponent<CircleCollider2D>().radius = colider.radius;
                    Destroy(m_bullet, 0.40f);
                    break;
            }
        }
        switch (m_nextFire < FireRate)
        {
            case true:
                a = false;
                break;
            case false:
                a = true; break;
        }
        switch (a)
        {
            case true:
                balls.SetActive(true);
                break;
            case false:
                balls.SetActive(false);
                break;
        }
    }
}