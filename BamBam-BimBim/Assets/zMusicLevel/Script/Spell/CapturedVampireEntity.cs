using UnityEngine;
using UnityEngine.UI;
public class CapturedVampireEntity : Spell
{
    public Image image;
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
                image.GetComponent<Image>().color = new Color32(255, 100, 100, 255);
                break;
            case false:
                image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
