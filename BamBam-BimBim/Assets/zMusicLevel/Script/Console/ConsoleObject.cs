using UnityEngine;
public class ConsoleObject : MonoBehaviour
{
    public string input;
    public bool closeConsole = true;
    public static ConsoleObject instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Obj();
        }
    }
    public void Obj()
    {
        closeConsole = !closeConsole;
        switch (closeConsole)
        {
            case true:
                Time.timeScale = Time.timeScale + 1;
                break;
            case false:
                Time.timeScale = Time.timeScale - 1;
                break;
        }
    }
    void OnGUI()
    {
        if (closeConsole) { return; }
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"");
        input = GUI.TextField(new Rect(10,25,Screen.width-20, 500), input);
    }
}