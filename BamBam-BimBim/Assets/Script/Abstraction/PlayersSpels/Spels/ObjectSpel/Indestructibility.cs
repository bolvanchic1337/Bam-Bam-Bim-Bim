using UnityEngine;
public class Indestructibility : MonoBehaviour
{
    public float power;
    public bool active;
    private void Start()
    {
        active = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb) && other.gameObject.TryGetComponent<Transform>(out Transform trans))
        {
            if (!active)
            {
                rb.velocity = new Vector2(other.gameObject.transform.localScale.x * power, 0f);
                trans.eulerAngles = new Vector3(0, -180, 0);
            }
        }
    }
}