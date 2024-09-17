using UnityEngine;
public class MagicMatrix : Spell
{
    public GameObject matrix;
    public ActualBPM actualBPM;
    public bool a;
    public override void Update()
    {
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
    }
    public void Cast()
    {
        if (coolDown < 0)
        {
            if (stats.mana >= 3)
            {
                switch (a)
                {
                    case true:

                        break;
                    case false:

                        break;
                }
                stats.mana -= 3;
                coolDown = curCoolDown;
                block.SetActive(true);
                matrix.SetActive(true);
                matrix.transform.localScale = new Vector3(matrix.transform.localScale.x + actualBPM.bpm.slider.value, matrix.transform.localScale.y + actualBPM.bpm.slider.value, matrix.transform.localScale.z);
                actualBPM.value--;
                if (actualBPM.value<0)
                {
                }
            }
        }
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
        value++;
    }
}