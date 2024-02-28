using UnityEngine;
public class JudgmentDay : Spell
{
    public float valueMax;
    public float valueMin;
    public Animator animator;
    public AstronautStats a;
    public override void Update()
    {
        valueMax = Mathf.Max(stats.strength, stats.inteligence, stats.agillity);
        valueMin = Mathf.Min(stats.strength, stats.inteligence, stats.agillity);
        base.Update();
        switch(stats.agillity == stats.strength && stats.agillity == stats.inteligence)
        {
            case true:
                animator.SetBool("Red", false);
                break;
            case false:
                animator.SetBool("Red", true);
                break;
        }
    }
    public void Cast()
    {
        if (coolDown < 0)
        {
            if (stats.mana >= 5)
            {
                stats.mana -= 5;
                coolDown = curCoolDown;
                block.SetActive(true);
                    Ult();
            }
        }
    }
    private void Ult()
    {
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
    }
    public override void Plus()
    {
        switch (a.spel && a.expLVL > 5)
        {
            case true:
                isActive = false;
                stats.lvlCount--;
                spels.lvlCount--;
                a.active = false;
                block.SetActive(false);
                break;
        }
    }
}