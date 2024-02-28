using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    public PickUp peeckUp;
    public InventoryManager inventoryManager;
    public float pickCount;
    public GameObject player;
    void Update()
    {
        if (pickCount >= 4)
        {
            pickCount = 4;
        }
        switch (player.transform.localScale.x == -2)
        {
            case true:
                Vector3 newRotation = new Vector3(0, -180, 0);
                transform.eulerAngles = newRotation;
                break;
            case false:
                Vector3 newRotation1 = new Vector3(0, 0, 0);
                transform.eulerAngles = newRotation1;
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl) && pickCount < 4 || Input.GetKey(KeyCode.RightControl) && pickCount < 4)
        {
            case true:
                a();
                break;
        }
    }
    public void a()
    {
        peeckUp.Next(peeckUp.item.value);
    }
}