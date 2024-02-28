using UnityEngine;
public class InvUI : MonoBehaviour
{
    public static InvUI instance;
    public InventorySlot[] invSlot;
    public Transform slotsParent;
    public Base item;
    protected bool enDis;
    protected int curInvIcon;
    protected int invIcon;
    void Awake()
    {
        curInvIcon = item.CurInvIcon;
        invIcon = item.InvIcon;
    }
    private void Start()
    {
        instance = this;
        for (int i = 0; i < invSlot.Length; i++)
        {
            invSlot[i] = slotsParent.GetChild(i).GetComponent<InventorySlot>();
        }
    }
    public void PutInEmprtySlot(Base item, GameObject obj)
    {
        for (int i = 0; i < invSlot.Length; i++)
        {
            if (invSlot[i].slotItem == null)
            {
                invSlot[i].PutInSlot(item, obj);
                return;
            }
        }
    }
}
