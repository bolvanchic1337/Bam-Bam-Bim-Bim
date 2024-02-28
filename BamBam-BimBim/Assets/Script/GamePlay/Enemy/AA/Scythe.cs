using Pathfinding;
using System.Collections;
using UnityEngine;
public class Scythe : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private CircleCollider2D colider;
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private AIPath aIPath;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;
    [SerializeField]
    private objectsStats[] stat;
    public GameObject myPrefab;
    public GameObject[] egg;
    public GameObject philactery;
    public Transform haterSpawn;
    public bool immortal;
    public float timer =9;
    private float curTimer =9;
    private float dist;
    public int d;
    private void OnEnable()
    {
        immortal = true;
        egg[0].SetActive(true);
        egg[1].SetActive(true);
    }
    void Update()
    {
        aIPath.maxSpeed = movement.runSpeed;
        dist = Vector3.Distance(player.position, transform.position);
        transform.eulerAngles = new Vector3(0, 0, 0);
        timer -= Time.deltaTime;
        if (dist < distance)
        {
            animator.SetTrigger("attack");
        }
        switch (aIPath.desiredVelocity.x >= 0.01f)
        {
            case true:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case false:
                break;
        }
        switch (aIPath.desiredVelocity.x <= -0.01f)
        {
            case true:
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        switch (immortal)
        {
            case true:
                for (int i = 0; i < stat.Length; i++)
                {
                    stat[i].immortal = true;
                }
                break;
            case false:
                for (int i = 0; i < stat.Length; i++)
                {
                    stat[i].immortal = false;
                }
                break;
        }
        switch(timer<0)
        {
            case true:
                StartCoroutine(HaterSpawn());
                timer = curTimer;
                break;
        }
        switch (philactery==null)
        {
            case true:
                immortal = false;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "Spell")
        {
            animator.Play("Scythe_Abillity");
        }
        if (o.gameObject.tag == "Player" && o.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = stat[0];
        }
    }
    IEnumerator HaterSpawn()
    {
        animator.Play("Scythe_Summon");
        yield return new WaitForSeconds(0.5f);
        var a = new Quaternion(0,0, 0, 0);
        GameObject m_bullet = Instantiate(myPrefab, haterSpawn.position,Quaternion.identity);
        m_bullet.transform.SetParent(haterSpawn);
        Rigidbody2D rb2 = m_bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(haterSpawn.up * 20, ForceMode2D.Impulse);
        if (transform.localScale.x >= 0)
        {
            m_bullet.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (transform.localScale.x <= 0)
        {
            m_bullet.transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
}                           