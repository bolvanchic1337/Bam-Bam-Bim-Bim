using UnityEngine;
using UnityEngine.UI;
public class ArcaneArrows : Spell
{
    public float arrows;
    private float AACoolDown = 5;
    private float AACurcoolDown = 5;
    public bool active;
    public Image image;
    public override void Plus()
    {
        base.Plus();
        AACurcoolDown--;
    }
    public override void Update()
    {
            base .Update();

        arrows = Mathf.Floor(arrows);
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
        AACoolDown -= Time.deltaTime;
        if ( AACoolDown <= 0 )
        {
            AACoolDown = AACurcoolDown;
            arrows++;
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
        active = !active;
        if ( active )
        {
            image.GetComponent<Image>().color = new Color32(255, 0, 225, 255);
        }
        else
        {
            image.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
    }
    public void A()
    {
        arrows = 0;
    }
}