using UnityEngine;
public class Buy : MonoBehaviour
{
    public float count;
    public PlayerStats stats;
    public GameObject item;
    public PickUp pickUp;
    public void Waste()
    {
        if(stats.money >= count && pickUp.item.name != "1" && stats.inventoryManager.pickCount<4)
        {
            stats.manager.curPlayerStats.money -= count;
            pickUp.StatsEquals();
            pickUp.Next(pickUp.item.value);
            Destroy(gameObject);
        }
        else if(stats.money >= count && pickUp.item.name == "1")
        {
            stats.manager.curPlayerStats.money -= count;
            stats.AganimBottom();
            Destroy(pickUp.gameObject);
            Destroy(item);
            Destroy(gameObject);
        }
    }
}