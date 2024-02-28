using UnityEngine;
public class Rickoshet : MonoBehaviour
{
    public float currentSpeed;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            Vector2 reflectDir = Vector2.Reflect(rb.transform.position.normalized, other.transform.position.normalized);
            float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            Debug.Log(rot);
            rb.transform.eulerAngles = new Vector3(0, 0, rot);
            currentSpeed *= 0.75f;
            rb.velocity = Vector2.Reflect(-other.relativeVelocity.normalized, other.contacts[0].normal) * currentSpeed;
        }
    }
}