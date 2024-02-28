using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public GameObject player;
    public Manager manager;
    public PlayerSelect playerSelect;
    public PlayerSpels spels;
    public PlayerStats stats;
    public GameObject[] enableObjects;
    public GameObject[] disableObjects;
    public PlayerMovement playerMovement;
    private float lastClick;
    public float dobleClickTime;
    public Sprite[] spriteSpel;
    public Hints[] hints;
    public string[] hintsText;
    public bool a;
    private void Start()
    {
        dobleClickTime = 0.2f;
    }
    public void OnMouseDown()
    {
        float timeSinceLastClick = Time.time - lastClick;
        if (timeSinceLastClick <= dobleClickTime)
        {
            Next();
        }
        lastClick = Time.time;
    }
    public void Next()
    {
        //Stats UI
        manager.player = playerSelect;
        manager.playerStats = stats;
        manager.playerMovement = playerMovement;
        manager.curPlayer = player;
        manager.playerImage.sprite = stats.sprite;
        //Enable/Disable Objects
        for (int i = 0; i < disableObjects.Length; i++)
        {
            disableObjects[i].SetActive(false);
        }
        for (int i = 0; i < enableObjects.Length; i++)
        {
            enableObjects[i].SetActive(true);
        }
        //Sprite
        if (!a)
        {
            manager.spelSprite[0].sprite = spriteSpel[0];
            manager.spelSprite[1].sprite = spriteSpel[1];
            manager.spelSprite[2].sprite = spriteSpel[2];
            manager.spelSprite[3].sprite = spriteSpel[3];
        }
        //Hint Text
        if (!a)
        {
            hints[0].hintString = hintsText[0];
            hints[1].hintString = hintsText[1];
            hints[2].hintString = hintsText[2];
            hints[3].hintString = hintsText[3];
        }
    }
}