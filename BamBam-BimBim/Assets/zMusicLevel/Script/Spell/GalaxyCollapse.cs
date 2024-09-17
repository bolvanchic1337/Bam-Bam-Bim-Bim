using UnityEngine;
using UnityEngine.UI;
public class GalaxyCollapse : Spell
{
    public Image image;
    public bool active = false;
    public GameObject a;
    public byte r = 255;
    public byte b =255;
    public override void Update()
    {
        base.Update();
        image.GetComponent<Image>().color = new Color32(r, 255, b, 255);
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
        switch (lvlLimit>0)
        {
            case true:
                if (stats.lvlCount > 0)
                {
                    a.SetActive(true);
                }
                break;
            case false:
                a.SetActive(false);
                break;
        }
    }
    public void Cast()
    {
       r-=15;
       b-=15;
        stats.mana--;
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
        value++;
    }
}