using UnityEngine;
public class CB : MonoBehaviour
{
    public Rigidbody2D rb;
    public float time;
    void Update()
    {
        time-=Time.deltaTime;
        if(time < 0 )
        {
           rb.AddForce(transform.right *0.01f, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.TryGetComponent(out PlayerStats stats))
        {
            stats.hp--;
        }
    }
}
