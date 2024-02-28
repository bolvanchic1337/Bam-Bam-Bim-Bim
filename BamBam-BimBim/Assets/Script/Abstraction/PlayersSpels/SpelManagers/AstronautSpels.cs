using UnityEngine;
using UnityEngine.UI;
public class AstronautSpels : PlayerSpels
{
    [Header("OnClick")]
    public PlayerSelect playerSelect;
    public bool activeAttack;
    [Header("Cursorses")]
    public Texture2D cursorDefault;
    public Button[] button;
    public Button[] buttonPlus;
    public Spell[] spell;
    private void Start()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }
    private  void Update()
    {
        if (Input.GetKeyDown(firstSpell) && spell[0].coolDown < 0 && !Input.GetKey(KeyCode.LeftControl))
        {
                button[0].onClick.Invoke();
        }
        else if (Input.GetKeyDown(secondSpell) && spell[1].coolDown < 0 && !Input.GetKey(KeyCode.LeftControl))
        {
            button[1].onClick.Invoke();
        }
        else if (Input.GetKeyDown(ThurdSpell) && spell[2].coolDown < 0 && !Input.GetKey(KeyCode.LeftControl))
        {
            button[2].onClick.Invoke();
        }
        else if (Input.GetKeyDown(UltimateSpell) && spell[3].coolDown < 0 && !Input.GetKey(KeyCode.LeftControl))
        {
            button[3].onClick.Invoke();
        }
        switch (Input.GetKeyDown(tabClick))
        {
            case true:
                playerSelect.Next();
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(firstSpell) && spell[0].lvlLimit > 0 && stats.lvlCount > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(firstSpell) && spell[0].lvlLimit > 0 && stats.lvlCount > 0)
        {
            case true:
                buttonPlus[0].onClick.Invoke();
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(secondSpell) && spell[1].lvlLimit > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(secondSpell) && spell[1].lvlLimit > 0)
        {
            case true:
                if (stats.lvlCount > 0)
                {
                    buttonPlus[1].onClick.Invoke();
                }
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(ThurdSpell) && spell[2].lvlLimit > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(ThurdSpell) && spell[2].lvlLimit > 0)
        {
            case true:
                if (stats.lvlCount > 0)
                {
                    buttonPlus[2].onClick.Invoke();
                }
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(UltimateSpell) || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(UltimateSpell))
        {
            case true:
                if (stats.lvlCount > 0)
                {
                    buttonPlus[3].onClick.Invoke();
                }
                break;
        }
    }
}