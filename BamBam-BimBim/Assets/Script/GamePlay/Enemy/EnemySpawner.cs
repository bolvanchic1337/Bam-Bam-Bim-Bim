using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public float m_nextFire =4;
    public float count;
    public float curCount;
    public GameObject bullet;
    private GameObject m_bullet;
    public GameObject nextSpawner;
    public GameObject none;
    public float nextFloat;
    private int normalMode;
    private void Awake()
    {
        normalMode = PlayerPrefs.GetInt("normalMode");
        if (normalMode == 0)
        {
            curCount /= 2;
        }
    }
    void FixedUpdate()
    {
        nextFloat -=Time.deltaTime;
        count -= Time.deltaTime;
        if (bullet == null)
        {
            bullet = none;
        }
        if (nextSpawner == null)
        {
            nextSpawner = none;
        }
        if (count <= 0)
        {
            count = curCount;
            m_nextFire = m_nextFire + Time.fixedDeltaTime;
            Vector3 m_mousePosition = Input.mousePosition;
            m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
            m_mousePosition.z = 0;
            float m_fireAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
            if (m_mousePosition.x > this.transform.position.x)
            {
                m_fireAngle = -m_fireAngle;
            }
            m_nextFire = 0;
            m_bullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            m_bullet.SetActive(true);
            m_bullet.transform.eulerAngles = new Vector3(0, 0, m_fireAngle + 100);
        }
        switch (nextFloat <=0)
        {
            case true:
                nextSpawner.SetActive(true);
                break;
        }
    }
}