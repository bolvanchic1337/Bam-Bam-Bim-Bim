using UnityEditor;
using UnityEngine;
public class AttackStealer : Spell
{
    private bool attack;
    [Header("Cursorses")]
    public Texture2D cursorAttack;
    public Texture2D cursorDefault;
    public Buffs buff;
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
    private void FixedUpdate()
    {
        if (attack)
        {
            Cursor.SetCursor(cursorAttack, Vector2.zero, CursorMode.ForceSoftware);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hits = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                /*
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
                    {
                        EnemyStats.instance = stats;
                        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
                        EnemyStats.strength -= 1;
                        stats.strength += 1;
                        attack = false;
                    }
                    else
                    {
                        print(hits); 
                    }
                }
                */
                if (hits.collider.gameObject.tag == "Player" && hits.collider.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
                {
                    print(hits);
                    EnemyStats.instance = stats;
                    Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
                    EnemyStats.strength -= 1;
                    stats.strength += 1;
                    attack = false;
                }

            }
        }
    }
    public void Cast()
    {
        if (coolDown < 0)
        {
            if (stats.mana >= 2)
            {
                buff.Buff(value);
                stats.mana -= 2;
                attack = true;
                coolDown = curCoolDown;
                block.SetActive(true);
            }
        }
    }
    public override void Plus()
    {
        base.Plus();
        curCoolDown--;
    }
}