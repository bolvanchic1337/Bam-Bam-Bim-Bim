using System.Collections;
using UnityEngine;
public class Laguna : Spell
{
    public Animator animator;
    public float delay;
    public float curValue;
    public Buffs buffs;
    public override void Update()
    {
        base.Update();
        switch (delay < 0)
        {
            case true:
                delay = 0;
                break;
        }
        switch (value<0)
        {
            case true:
                value = 0;
                break;
        }
        switch (stats.lvlCount >= 1 && lvlLimit >= 1)
        {
            case true:
                plus.SetActive(true);
                break;
            case false:
                plus.SetActive(false);
                break;
        }

    }
    public void Cast()
    {
        if(coolDown < 0 || stats.mana >= 2)
        {
            stats.mana -= 2;
            StartCoroutine(Enumerator());
            instance.coolDown = instance.curCoolDown;
            instance.block.SetActive(true);
            block.SetActive(true);
        }
    }
    IEnumerator Enumerator()
    {
        animator.SetBool("Start", true);
        yield return new WaitForSeconds(delay);
        do
        {
            buffs.value--;
            stats.hp += curValue;
            stats.inteligence--;
            delay -= 0.4f;
            value--;
        } while (value>=1);
        animator.SetBool("Start", false);
    }
    public override void Plus()
    {
        base.Plus();
        curValue++;
    }
}