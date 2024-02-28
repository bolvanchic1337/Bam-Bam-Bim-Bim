using UnityEngine;
public class Cheats : MonoBehaviour
{
    public Manager Manager;
    public void Cheat()
    {
        Manager.playerStats.maxHp += 1000;
        Manager.playerStats.hp += 1000;
        Manager.playerStats.maxMana += 1000;
        Manager.playerStats.mana += 1000;
        Manager.playerStats.agillity += 100;
        Manager.playerStats.inteligence += 100;
        Manager.playerStats.money -= 3402823000;
    }
}