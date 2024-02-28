using UnityEngine;
public class Haters : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject,3);
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player" && o.gameObject.TryGetComponent(out PlayerStats stats) && o.gameObject.name != "Scythe")
        {
            float damage = stats.inteligence;
            stats.inteligence /= 2;
            stats.Damage("magical", damage);
            Destroy(gameObject);
        }
    }
}
