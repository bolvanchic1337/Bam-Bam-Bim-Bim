using UnityEngine;
public class ChtonicalWall : Spell
{
    public GameObject wall;
    private float delay;
    public override void Update()
    {
        delay -= Time.deltaTime;
        base.Update();
        switch (stats.lvlCount >= 1 && lvlLimit >= 1)
        {
            case true:
                plus.SetActive(true);
                break;
            case false:
                plus.SetActive(false);
                break;
        }
        switch (delay <0)
        {
            case true:
                wall.SetActive(false);
                break;
        }
    }
    public void Cast()
    {
        if (coolDown < 0)
        {
            if (stats.mana >= 3)
            {
                delay = value;
                stats.mana -= 3;
                coolDown = curCoolDown;
                block.SetActive(true);
                wall.SetActive(true);
            }
        }
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
        value++;
    }
    public ChtonicalWall()
    {
        value = 2;
    }
}