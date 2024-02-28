using UnityEngine;
public class ImpulsiveCircle : Spell
{
    public GameObject circle;
    public float delay;
    public override void Update()
    {
        base.Update();
        delay -= Time.deltaTime;
        switch (delay <= 0)
        {
            case true:
                circle.SetActive(false);
                break;
            case false:
                circle.SetActive(true);
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
        if (instance.coolDown < 0)
        {
            if (stats.mana >= 3)
            {
                stats.mana -= 3;
                delay = value;
                instance.coolDown = instance.curCoolDown;
                circle.SetActive(true);
                instance.block.SetActive(true);
            }
        }
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
    }
}