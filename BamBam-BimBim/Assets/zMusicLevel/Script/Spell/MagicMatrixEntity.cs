using UnityEngine;
using System.Collections;
public class MagicMatrixEntity : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private bool isActive;
    public float time;
    public MagicMatrix mm;

    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
        transform.localScale = Vector3.one;
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,player.position.z-1);
        if (isActive)
        {
            StartCoroutine(Active());
        }
    }
    IEnumerator Active()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats) && other.gameObject.name != "ArchMage")
        {
            EnemyStats.Damage("pure", mm.value);
            if (mm.a)
            {
                EnemyStats.Damage("pure", mm.value);
            }
        }
    }
}