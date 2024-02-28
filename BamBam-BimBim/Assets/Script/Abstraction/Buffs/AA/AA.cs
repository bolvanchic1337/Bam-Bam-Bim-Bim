using UnityEngine;
public class AA : Buffs
{
    public ArcaneArrows arcaneArrows;
    private void FixedUpdate()
    {
        value = arcaneArrows.arrows;
    }
}