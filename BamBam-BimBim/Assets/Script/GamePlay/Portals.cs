using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform t;
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            o.gameObject.transform.position = t.position;
        }
    }
}
