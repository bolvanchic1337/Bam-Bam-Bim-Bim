using UnityEngine;
public class MagicShield : Spell
{
    public GameObject objectInstance;
    public Transform spawnPoint;
    private GameObject shield;
    public ArcaneArrows AA;
    public objectsStats objectsStat;
    private void OnEnable()
    {
        objectsStat.hp += AA.arrows;
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
        value++;
    }
    public override void Update()
    {
        base.Update();
        switch (coolDown <= 0)
        {
            case true:
                block.SetActive(false);
                break;
        }
        switch (!isActive)
        {
            case true:
                coolDownString.text = coolDown.ToString();
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
        if (coolDown < 0)
        {
            if (stats.mana >= 3)
            {
                AA.arrows -=2;
                objectsStat.maxHp = value;
                objectsStat.hp = value;
                objectsStat.maxHp += AA.arrows;
                objectsStat.hp += AA.arrows;
                objectsStat.agillity += AA.arrows;
                objectsStat.inteligence += AA.arrows;
                stats.mana -= 1;
                shield = Instantiate(objectInstance, spawnPoint.position, Quaternion.identity);
                shield.transform.SetParent(spawnPoint);
                coolDown = curCoolDown;
                block.SetActive(true);
                Destroy(shield, value);
            }
        }
    }
    public MagicShield()
    {
        value = 1;
    }
}