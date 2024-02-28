using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public Manager manager;
    private void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
    }
}
