using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyOnDestroy : MonoBehaviour
{
    public Manager manager;
    public float money;

    private void OnDestroy()
    {
        manager.curPlayerStats.money += money;
    }
}
