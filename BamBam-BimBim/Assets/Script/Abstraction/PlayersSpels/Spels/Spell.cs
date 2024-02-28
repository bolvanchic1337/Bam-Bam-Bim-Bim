using UnityEngine;
using UnityEngine.UI;
public abstract class Spell : MonoBehaviour
{
    [Header("spell")]
    public PlayerStats stats;
    public GameObject plus;
    public GameObject block;
    public PlayerSpels spels;
    public Text coolDownString;
    public float coolDown;
    public float curCoolDown;
    public Spell instance;
    public float value;
    public float lvlLimit;
    public bool isActive = true;
    public void Start()
    {
        isActive = true;
    }
    public virtual void Update()
    {
        switch(coolDown <= 0)
        {
            case true:
            block.SetActive(false);
                break;
        }
        switch (!isActive)
        {
            case true:
                coolDown -= Time.deltaTime;
                coolDownString.text = coolDown.ToString();
                break;
        }
    }
    public virtual void Active()
    {
         isActive = false;
    }
    public virtual void Plus()
    {
        isActive = false;
        stats.lvlCount--;
        value++;
        lvlLimit--;
    }
}