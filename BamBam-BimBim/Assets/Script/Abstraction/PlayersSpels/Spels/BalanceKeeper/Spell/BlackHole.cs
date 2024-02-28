using System.Collections;
using UnityEngine;
public class BlackHole : MonoBehaviour
{
    public JudgmentDay state;
    public Animator animator;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = state.stats;
            state.a.manager.curPlayerStats.aganimTopObject.SetActive(true);
            state.a.manager.curPlayerStats.aganimTop = false;
            state.a.manager.curPlayerStats.aganimSpell.SetActive(false);
            if (state.stats.inteligence == state.valueMax)
             {
                 EnemyStats.Damage("magical", state.a.attack);
                A();
             }
             else if (state.stats.agillity == state.valueMax)
             {
                 EnemyStats.Damage("pure", state.a.attack);
                A();
            }
            else if (state.stats.strength == state.valueMax)
             {
                 EnemyStats.Damage("physical", state.a.attack);
                A();
            }
            else if (state.stats.agillity == state.stats.strength && state.stats.agillity == state.stats.inteligence)
            {
                 EnemyStats.Damage("pure", state.a.attack);
                A();
            }
        }
    }
    private void A()
    {
        animator.SetTrigger("S");
        StartCoroutine(S());
    }
    IEnumerator S()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}