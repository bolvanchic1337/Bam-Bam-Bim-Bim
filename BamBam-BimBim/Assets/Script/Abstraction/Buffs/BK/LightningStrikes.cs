using UnityEngine;
public class LightningStrikes : Buffs
{
    public Laguna laguna;
    public override void Update()
    {
        base.Update();
        laguna.value = value;
    }
    public override void Buff(float count)
    {
        value++;
        stats.inteligence += count;
        laguna.delay += 0.4f;
        laguna.value++;
    }
}
