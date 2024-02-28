using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector] public Base slotItem;
    [HideInInspector] public Image icon;
    [HideInInspector] public Button button;
    [HideInInspector] public GameObject ItemObj;
    public GameObject info;
    [HideInInspector] public int ID;
    public void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SlotClicked);
    }

    public void PutInSlot(Base item, GameObject obj)
    {
        icon.sprite = item.icon;
        slotItem = item;
        ItemObj = obj;
        ID = item.ID;
        icon.enabled = true;
    }
    void SlotClicked()
    {
        if (slotItem != null)
            info.SetActive(true);
        ItemInfo.instance.Open(slotItem, ItemObj, this);
    }
    public void ClearSlot()
    {
        slotItem = null;
        ItemObj = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
