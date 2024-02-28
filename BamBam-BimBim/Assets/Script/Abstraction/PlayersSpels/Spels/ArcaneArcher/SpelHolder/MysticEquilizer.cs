using Pathfinding;
using UnityEngine;
public class MysticEquilizer : Spell
{
    public AstronautStats a;
    private GameObject projectile;
    public GameObject objectInstance;
    public Transform AA;
    private bool attack;
    public Texture2D cursorAttack;
    public Texture2D cursorDefault;
    public UltProjectile UP;
    public PlayerMovement playerMovement;
    public void FixedUpdate()
    {
        if (attack)
        {
            Cursor.SetCursor(cursorAttack, Vector2.zero, CursorMode.ForceSoftware);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement movement) && hit.collider.gameObject.TryGetComponent<AIPath>(out AIPath path))
                    {
                        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
                        float f = movement.runSpeed / 2;
                        path.maxSpeed /= 2;
                        playerMovement.runSpeed += f;
                        UP.player = hit.collider.gameObject;
                        projectile = Instantiate(objectInstance, AA.position, Quaternion.identity);
                        Destroy(projectile, 12);
                        attack = false;
                    }
                }
            }
        }
    }
    public void Cast()
    {
        if (coolDown < 0)
        {
            if (stats.mana >= 5)
            {
                attack = true;
                stats.mana -= 5;
                coolDown = curCoolDown;
                block.SetActive(true);
            }
        }
    }
    public override void Plus()
    {
        switch (a.spel && a.expLVL > 5)
        {
            case true:
                isActive = false;
                stats.lvlCount--;
                spels.lvlCount--;
                a.active = false;
                block.SetActive(false);
                break;
        }
    }
}