using UnityEngine;
public class Trampoline : MonoBehaviour
{
    public float force;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            print("");
        }
    }
}