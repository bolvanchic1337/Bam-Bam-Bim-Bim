using UnityEngine;
public class PickUp : InvUI
{
    public PlayerStats stats;
    public PickUp pickUp;
    public InventoryManager inventoryManager;
    public GameObject btn;
    public int id;
    [Header("bl")]
    public int index;
    public GameObject itemObj;
    public Manager manager;
    void Awake()
    {
        invIcon = item.InvIcon;
        curInvIcon = item.CurInvIcon;
    }
    void Start()
    {
        itemObj = gameObject;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        inventoryManager.peeckUp = pickUp;
        if (other.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            btn.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        inventoryManager.peeckUp =null;
        if (other.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            btn.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MainCharacter") && collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            stats = EnemyStats;
        }
        switch (collision.CompareTag("Bullet"))
        {
            case true:
                Destroy(collision.gameObject);
                ItemDestroy();
                break;
        }
    }
    void ItemDestroy()
    {
        switch (id)
        {
            case 0:
                print("");
                Destroy(gameObject);
                break;
            case 69103103:
                GameObject cat = Cat.cat.obj;
                var x = new Vector3(transform.position.x -3, transform.position.y);
                Instantiate(cat, x, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }
    public void Next(int value)
    {
        value = item.value;
        inventoryManager.pickCount++;
        instance.PutInEmprtySlot(item, itemObj);
        gameObject.SetActive(false);
        switch (value)
        {
            case 0:
                PlusStats(1, 1, 1);
                break;
            case 3:
                PlusStats(0,6, 0);
                break;
            case 4:
                PlusStats(0,0, 3);
                break;
            case 5:
                PlusStats(1, 1, 1);
                PlusMovement(15);
                break;
        }
    }
    private void PlusStats(float strength, float agillity, float inteligence)
    {
        stats.inteligence += inteligence;
        stats.agillity += agillity;
        stats.strength += strength;
    }
    private void PlusMovement(float movement)
    {
        stats.playerMovement.runSpeed += movement;
    }
    public void StatsEquals()
    {
        stats = manager.curPlayerStats;
    }
}