using UnityEngine;
public class OnClickShield : MonoBehaviour
{
    public objectsStats objectsStat;
    public PlayerStats stats;
    private void OnDestroy()
    {
        stats.hp += objectsStat.hp;
    }
}