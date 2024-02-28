using UnityEngine;
public class ShootEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject o;
    public Transform pos;
    public float dice;
    public objectsStats stats;
    public float f;
    private void OnEnable()
    {
        o.SetActive(true);
        dice = Random.Range(1, 7);
    }
    void Update()
    {
        dice -=Time.deltaTime;
        if (dice <=0 && stats.mana>=1)
        {
            stats.mana -= 1;
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject m_bullet = Instantiate(o, pos.position, Quaternion.identity);
        o.SetActive(false);
        Rigidbody2D rb2 = m_bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(pos.up * f, ForceMode2D.Impulse);
        Destroy(m_bullet,3);
    }
}