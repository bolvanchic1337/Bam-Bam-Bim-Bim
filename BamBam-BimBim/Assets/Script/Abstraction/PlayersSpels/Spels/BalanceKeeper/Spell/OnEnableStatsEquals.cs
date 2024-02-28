using UnityEngine;
public class OnEnableStatsEquals : MonoBehaviour
{
    public PlayerStats stats;
    public float valueMax;
    public float valueMin;
    public Animator animator;
    private void Update()
    {
        valueMax = Mathf.Max(stats.strength, stats.inteligence, stats.agillity);
        valueMin = Mathf.Min(stats.strength, stats.inteligence, stats.agillity);
        if (stats.strength == valueMax)
        {
            if (stats.inteligence == valueMin)
            {
                stats.inteligence = valueMax;
            }
            else if (stats.agillity == valueMin)
            {
                stats.agillity = valueMax;
            }
        }
        else if (stats.agillity == valueMax)
        {
            if (stats.inteligence == valueMin)
            {
                stats.inteligence = valueMax;
            }
            else if (stats.strength == valueMin)
            {
                stats.strength = valueMax;
            }
        }
        else if (stats.inteligence == valueMax)
        {
            if (stats.strength == valueMin)
            {
                stats.strength = valueMax;
            }
            else if (stats.agillity == valueMin)
            {
                stats.agillity = valueMax;
            }
        }
        switch (stats.strength == valueMax || stats.inteligence == valueMax)
        {
            case true:
                animator.SetBool("Red", true);
                break;
        }
        switch (stats.agillity == valueMax)
        {
            case true:
                animator.SetBool("Red", false);
                break;
        }
        switch (stats.agillity == stats.strength && stats.agillity == stats.inteligence)
        {
            case true:
                animator.SetBool("Red", false);
                break;
        }
    }
}