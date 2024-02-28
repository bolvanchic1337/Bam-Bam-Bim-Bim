using UnityEngine;
using Pathfinding;
public class UltProjectile : MonoBehaviour
{
    public int rotationOffset = -90;
    public GameObject player;
    public GameObject Arcane;
    public float speed;
    public MysticEquilizer equilizer;
    public ArcaneArrows AA;
    public PlayerStats stat;
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (player == null)
        {
            player = Arcane;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out AIPath path) && other.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = stat;
            float dist = Vector3.Distance(Arcane.transform.position, transform.position);
            dist = Mathf.Floor(dist);
            float damage = stat.attack + AA.arrows / dist;
            damage = Mathf.Floor(damage);
            stats.Damage("magical", damage);
            player = Arcane;
        }
        else if (other.gameObject.name == "ArcaneArcher")
        {
            AA.arrows /= 2;
            equilizer.a.mana = equilizer.a.maxMana;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out PlayerStats playerStats))
        {
            float dist = Vector3.Distance(Arcane.transform.position, transform.position);
            dist = Mathf.Floor(dist);
            float damage = stat.attack + AA.arrows / dist;
            damage = Mathf.Floor(damage);
            playerStats.Damage("magical", damage);
        }
    }
}