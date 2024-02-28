using UnityEngine;
public class LinkinSphereEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.CompareTag("Spell"))
        {
            o.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D o)
    {
        if (o.gameObject.CompareTag("Spell"))
        {
            o.gameObject.SetActive(false);
        }
    }
}