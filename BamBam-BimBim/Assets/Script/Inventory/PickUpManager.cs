using UnityEngine;
public class PickUpManager : MonoBehaviour
{
    public PickUp pickUp;
    public PickUpManager instance;
    public float picked;
    public static PickUpManager pickUpManager;
    private void Awake()
    {
        pickUpManager = this;
    }
    void Update()
    {
        instance =this;    
        if(picked >=4){
            picked =4;
        }    
    }
    public void a(PickUp item){
        item = pickUp;
            if(picked <4){
                item.Next(pickUp.item.value);
            }
    }
}