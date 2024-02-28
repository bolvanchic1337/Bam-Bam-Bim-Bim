using UnityEngine;
using UnityEngine.UI;
public abstract class Buffs : MonoBehaviour
{
    public float value;
    public GameObject holder;
    public Text countText;
    public PlayerStats stats;
    public virtual void Update()
    {
        countText.text = value.ToString();
        if(value > 0)
        {
            holder.SetActive(true);
        }
        else if (value <= 0)
        {
            holder.SetActive(false);
        }
        switch(value<=0)
        {
            case true:
                value = 0;
                break;
        }
    }
    public virtual void Buff(float count)
    {
    }
}