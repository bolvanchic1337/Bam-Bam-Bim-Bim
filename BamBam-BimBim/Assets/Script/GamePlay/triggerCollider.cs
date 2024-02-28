using UnityEngine;
public class triggerCollider : MonoBehaviour
{
    public Animator animator;
    public int stateEnter;
    private int shopOnMouse;
    private void Awake()
    {
        stateEnter = PlayerPrefs.GetInt("shopCollider");
        shopOnMouse = PlayerPrefs.GetInt("shopOnMouse");
    }
    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            if (stateEnter == 1)
            {
                Open();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            if (stateEnter == 1)
            {
                Close();
            }
        }
    }
    public void Close()
    {
        animator.SetBool("Close", false);
        animator.SetBool("Open", true);
    }
    private void Open()
    {
        animator.SetBool("Close", true);
        animator.SetBool("Open", false);
    }
    private void OnMouseUp()
    {
        if (shopOnMouse == 1)
        {
            Open();
        }
    }
}