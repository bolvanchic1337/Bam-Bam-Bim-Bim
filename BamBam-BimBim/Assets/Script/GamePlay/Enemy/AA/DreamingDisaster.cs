using System.Collections;
using UnityEngine;
using Pathfinding;
public class DreamingDisaster : MonoBehaviour
{
    [SerializeField]
    private objectsStats stat;
    [SerializeField]
    private Animator animator;
    private bool sleep = true;
    [SerializeField]
    private AIPath aIPath;
    [SerializeField]
    private PlayerMovement movement;
    [SerializeField]
    private CircleCollider2D circleCollider;
    [SerializeField]
    private CircleCollider2D circleCollider1;
    public GameObject skelet;
    private void OnDestroy()
    {
        skelet.SetActive(false);
    }
    void Update()
    {
        if(sleep)
        {
            if (stat.hp < stat.maxHp||stat.strength < 1)
            {
                StartCoroutine(Spawn());
                animator.SetTrigger("spawn");
                sleep = false;
            }
        }
        switch (transform.position.y >0.5f)
        {
            case true:
                transform.position = new Vector2(transform.position.x, -0.5f);
                break;
        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("walk");
        aIPath.maxSpeed = movement.runSpeed;
        circleCollider.offset = new Vector2(0,0);
        circleCollider.radius = 1.6f;
        circleCollider1.radius = 1.7f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Spawn());
            animator.SetTrigger("spawn");
            sleep = false;
        }
        if (collision.gameObject.tag == "Player" && collision.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = stat;
        }
    }
}