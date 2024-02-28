using System.Collections;
using UnityEngine;
public class objectsStats : PlayerStats
{
    [Header("Object")]
    public PlayerStats stats;
    public string damageType;
    public GameObject spawn;
    private void OnDestroy()
    {
        manager.playerStats.instance.money+= money;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
                EnemyStats.instance = stats;
                EnemyStats.Damage(damageType, attack);
        }
    }
    public override void Limbus()
    {
        StartCoroutine(Reincarnation());
        gameObject.GetComponent<PlayerSelect>().enabled = false;
        animator.SetTrigger("Reincarnation");
        hp = maxHp;
        strength = maxHp;
    }
    public override IEnumerator Reincarnation()
    {
        yield return new WaitForSeconds(animationDelay);
        gameObject.GetComponent<PlayerSelect>().enabled = true;
        hp = maxHp;
        strength = maxHp;
        gameObject.transform.position = spawn.transform.position;
        immortal = false;
        hp = maxHp;
        strength = maxHp;
    }
}