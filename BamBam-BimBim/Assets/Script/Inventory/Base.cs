using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Base : ScriptableObject
{
    public int ID;
    public Sprite icon;
    int invIcon;
    public int InvIcon { get => invIcon; set => invIcon = value; }
    int curInvIcon;
    public int CurInvIcon { get => curInvIcon; set => curInvIcon = value; }
    public string Name;
    public int value;
    public int count;
    public int startCount;
}