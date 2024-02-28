using UnityEngine;
using UnityEngine.UI;
public class ItemInfo : MonoBehaviour
{
    private Base infoItem;
    private InventorySlot CurrentSlot;
    [SerializeField]
    private InventorySlot[] slots;
    public static ItemInfo instance;
    public Text Name;
    private GameObject ItemObj;
    public GameObject inventoryObject;
    public InventoryManager inventoryManager;
    public WASD wasd;
    public GameObject player;
    public PlayerStats stats;
    public int updateStatus;
    public Manager manager;
    [Header("POZOR")]
    [HideInInspector]
    public int ptState =0;
    public PickUp[] pickUp;
    void Start()
    {
        instance = this;
    }
    public void ChangeInfo(Base item)
    {
        Name.text = item.Name;
    }
    public void Update()
    {
        if (updateStatus ==1)
        {
            Cursor.SetCursor(manager.cursor[1], Vector2.zero, CursorMode.ForceSoftware);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
                    {
                        EnemyStats.instance = stats;
                        Cursor.SetCursor(manager.cursor[0], Vector2.zero, CursorMode.ForceSoftware);
                        EnemyStats.strength -= 1;
                        float value = stats.inteligence / 2;
                        value = Mathf.Floor(value);
                        print(value);
                        EnemyStats.hp -= value;
                        stats.hp += value;
                        updateStatus = 0;
                    }
                }
            }
        }
    }
    public void Open(Base item, GameObject itemObj, InventorySlot currentSlot){
       ChangeInfo(item);
       inventoryObject.SetActive(true);
       ItemObj = itemObj;
       CurrentSlot =currentSlot;
       infoItem = item;
    }
    public void Close(){
       inventoryObject.SetActive(false);
    }
    public void Drop()
    {
        if (player.transform.localScale.x == -2)
        {
            inventoryManager.pickCount--;
            CurrentSlot.info.SetActive(false);
            Vector3 DropPos = new Vector3(wasd.instance.transform.position.x - 2f, wasd.instance.transform.position.y, wasd.instance.transform.position.z);
            ItemObj.SetActive(true);
            ItemObj.transform.position = DropPos;
            CurrentSlot.ClearSlot();
        }
        else if (player.transform.localScale.x == 2)
        {
            inventoryManager.pickCount--;
            CurrentSlot.info.SetActive(false);
            Vector3 DropPos = new Vector3(wasd.instance.transform.position.x + 2f, wasd.instance.transform.position.y, wasd.instance.transform.position.z);
            ItemObj.SetActive(true);
            ItemObj.transform.position = DropPos;
            CurrentSlot.ClearSlot();
        }
        switch (infoItem.value)
        {
            case 0:
                stats.aganimSpell.SetActive(false);
                stats.aganimTopObject.SetActive(true);
                stats.aganimTop = false;
                Minustats(1, 1, 1);
                break;
            case 3:
                stats.aganimSpell.SetActive(false);
                stats.aganimTopObject.SetActive(true);
                stats.aganimTop = false;
                Minustats(0, 6, 0);
                break;
            case 5:
                MinusMovement(15);
                switch (ptState)
                {
                    case 0:
                        Minustats(1, 1, 1);
                        CurrentSlot.icon.color = new Color32(255, 255, 225, 255);
                        ptState = 0;
                        break;
                    case 1:
                        Minustats(3, 0, 0);
                        CurrentSlot.icon.color = new Color32(255, 255, 225, 255);
                        ptState = 0;
                        break;
                    case 2:
                        Minustats(0, 3, 0);
                        CurrentSlot.icon.color = new Color32(255, 255, 225, 255);
                        ptState = 0;
                        break;
                    case 3:
                        Minustats(0, 0, 3);
                        CurrentSlot.icon.color = new Color32(255, 255, 225, 255);
                        ptState = 0;
                        break;
                }
                break;
        }
    }
    private void Minustats(float strength, float agillity, float inteligence)
    {
        stats.inteligence -= inteligence;
        stats.agillity -= agillity;
        stats.strength -= strength;
    }
    private void Plustats(float strength, float agillity, float inteligence)
    {
        stats.inteligence += inteligence;
        stats.agillity += agillity;
        stats.strength += strength;
    }
    private void MinusMovement(float movement)
    {
        stats.playerMovement.runSpeed -= movement;
    }
    public void Use()
    {
        switch (infoItem.value)
        {
            case 0:
                if(stats.mana >= 2 && stats.mana >= 2)
                {
                    stats.mana -= 2;
                    stats.AganimTop();
                }
                break;
            case 2:
                if(infoItem.count >= 0)
                {
                    infoItem.count--;
                    stats.mana += 5;
                    if (infoItem.count <= 0)
                    {
                        Drop();
                        ItemObj.SetActive(false);
                    }
                }
                break;
            case 4:
                if(infoItem.count >= 0 && stats.mana >= 1)
                {
                    infoItem.count--;
                    updateStatus = 1;
                    stats.mana -= 1;
                    if (infoItem.count <= 0)
                    {
                        Drop();
                        ItemObj.SetActive(false);
                    }
                }
                break;
            case 5:
                ptState++;
                switch (ptState)
                {
                    case 1:
                        Minustats(1, 1, 1);
                        Plustats(3, 0, 0);
                        CurrentSlot.icon.color = new Color32(255, 0, 0, 255);
                        break;
                    case 2:
                        Minustats(3, 0, 0);
                        Plustats(0, 3, 0);
                        CurrentSlot.icon.color = new Color32(0, 255, 0, 255);
                        break;
                    case 3:
                        Minustats(0, 3, 0);
                        Plustats(0, 0, 3);
                        CurrentSlot.icon.color = new Color32(0, 195, 225, 255);
                        break;
                    case 4:
                        Minustats(0, 0, 3);
                        Plustats(1, 1, 1);
                        CurrentSlot.icon.color = new Color32(255, 255, 225, 255);
                        ptState = 0;
                        break;
                }
                break;
            case 6:
                stats.mana = stats.maxMana;
                stats.hp = stats.maxHp;
                if (infoItem.count <= 0)
                {
                    Drop();
                    ItemObj.SetActive(false);
                }
                break;
            case 7:
                if(infoItem.count >= 0 && stats.mana >= 3)
                {
                    infoItem.count--;
                    stats.mana += 3;
                    stats.immortal = true;
                    if (infoItem.count <= 0)
                    {
                        Drop();
                        ItemObj.SetActive(false);
                    }
                }
                break;

            case 101:
                infoItem.count--;
                if (infoItem.count <= -1)
                {
                    Drop();
                    ItemObj.SetActive(false);
                    inventoryManager.peeckUp = pickUp[0];
                    inventoryManager.a();
                }
                break;
            case 102:
                infoItem.count--;
                if (infoItem.count <= -1)
                {
                    Drop();
                    ItemObj.SetActive(false);
                    inventoryManager.peeckUp = pickUp[1];
                    inventoryManager.a();
                }
                break;
        }
    }
}