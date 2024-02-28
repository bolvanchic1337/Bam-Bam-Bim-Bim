using System.Collections;
using UnityEngine;
using Pathfinding;
public class AnnoyOTron : MonoBehaviour
{
    public Indestructibility indestructibility;
    public float time = 4.4f;
    public float curTime = 4.4f;
    public Animator animator;
    [SerializeField]
    private AIPath aIPath;
    [SerializeField]
    private PlayerMovement movement;
    public PlayerStats stat;
    void Update()
    {
        aIPath.maxSpeed = movement.runSpeed;
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = curTime;
            StartCoroutine(EndTime());
        }
    }
     IEnumerator EndTime()
    {
        indestructibility.active = true;
        animator.SetTrigger("block");
        yield return new WaitForSeconds(1.1f);
        indestructibility.active = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.instance = stat;
        }
    }
}