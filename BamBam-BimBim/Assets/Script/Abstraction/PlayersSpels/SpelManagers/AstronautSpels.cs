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
        switch (!Input.GetKey(KeyCode.LeftControl))
        {
            case true:
                if (Input.GetKeyDown(firstSpell) && spell[0].coolDown < 0)
                {
                    button[0].onClick.Invoke();
                }
                if (Input.GetKeyDown(secondSpell) && spell[1].coolDown < 0)
                {
                    button[1].onClick.Invoke();
                }
                 if (Input.GetKeyDown(ThurdSpell) && spell[2].coolDown < 0)
                {
                    button[2].onClick.Invoke();
                }
                 if (Input.GetKeyDown(UltimateSpell) && spell[3].coolDown < 0)
                {
                    button[3].onClick.Invoke();
                }
                break;
        }
        switch (Input.GetKey(KeyCode.LeftControl))
        {
            case true:
                if (Input.GetKeyDown(firstSpell) && spell[0].lvlLimit > 0 && stats.lvlCount > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(firstSpell) && spell[0].lvlLimit > 0 && stats.lvlCount > 0)
                {
                    buttonPlus[0].onClick.Invoke();
                }
                if (Input.GetKeyDown(secondSpell) && spell[1].lvlLimit > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(secondSpell) && spell[1].lvlLimit > 0)
                {
                    buttonPlus[1].onClick.Invoke();
                }
                if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(ThurdSpell) && spell[2].lvlLimit > 0 || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(ThurdSpell) && spell[2].lvlLimit > 0))
                {
                    buttonPlus[2].onClick.Invoke();
                }
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(UltimateSpell) || Input.GetKey(KeyCode.RightControl) && Input.GetKeyDown(UltimateSpell))
                {
                    if (stats.lvlCount > 0)
                    {
                        buttonPlus[3].onClick.Invoke();
                    }
                }
                break;
        }
    }
}