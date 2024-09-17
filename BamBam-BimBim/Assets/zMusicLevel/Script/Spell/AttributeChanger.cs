using UnityEngine;
using UnityEngine.UI;
public class AttributeChanger : Spell
{
    public Image image;
    public Sprite red;
    public Sprite blue;
    public bool active = false;
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
    }
    private void FixedUpdate()
    {
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
        active = !active;
        switch (active)
        {
            case true:
                image.sprite = red;

                break;
            case false:
                image.sprite = blue;

                break;
        }
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
        value++;
    }
}