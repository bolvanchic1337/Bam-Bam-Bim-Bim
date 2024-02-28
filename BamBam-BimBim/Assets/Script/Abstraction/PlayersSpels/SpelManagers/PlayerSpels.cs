using UnityEngine;
public abstract class PlayerSpels : MonoBehaviour
{
    public GameObject spelHandler;
    public GameObject[] spelHandlers;
    public Manager manager;
    public PlayerSpels instance;
    public PlayerStats stats;
    public float lvlCount;
    [Header("KeyCode")]
    public KeyCode tabClick = KeyCode.Tab;
    public KeyCode firstSpell = KeyCode.Q;
    public KeyCode secondSpell = KeyCode.W;
    public KeyCode ThurdSpell = KeyCode.E;
    public KeyCode UltimateSpell = KeyCode.R;
}