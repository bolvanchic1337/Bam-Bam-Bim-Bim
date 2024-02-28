using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public GameObject curPlayer;
    public PlayerSelect player;
    public PlayerStats playerStats;
    public PlayerStats curPlayerStats;
    public Image playerImage;
    public PlayerMovement playerMovement;
    public WASD wasd;
    public PlayerSpels spels;
    public InventoryManager inventoryManager;
    public Image[] spelSprite;
    public Texture2D[] cursor;
    public static Manager manager;
    public void Awake()
    {
        manager = this;
    }
}