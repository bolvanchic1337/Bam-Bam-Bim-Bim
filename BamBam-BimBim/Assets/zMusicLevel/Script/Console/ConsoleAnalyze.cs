using UnityEngine;
public class ConsoleAnalyze : MonoBehaviour
{
    private ConsoleObject consoleObject;
    public ConsoleCommand[] cc;
    public PlayerStats stats;
    public PlayerMovement movement;
    private void Start()
    {
        consoleObject = ConsoleObject.instance;
        consoleObject.input = "напишите команду например help и нажмите клавишу Enter или ПКМ";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1))
        {
            try
            {
                if (consoleObject.input.Contains("help"))
                {
                    consoleObject.input = ConsoleHelp.instance.description;
                }
                if (consoleObject.input.Contains("end"))
                {
                    consoleObject.Obj();
                }
                if (consoleObject.input.Contains("calculations+"))
                {
                    ConsoleCalculations.instance.Function();
                }
                if (consoleObject.input.Contains("calculations-"))
                {
                    ConsoleCalculations.instance.Function1();
                }
                if (consoleObject.input.Contains("calculations/"))
                {
                    ConsoleCalculations.instance.Function2();
                }
                if (consoleObject.input.Contains("calculations*"))
                {
                    ConsoleCalculations.instance.Function3();
                }
                if (consoleObject.input.Contains("log"))
                {
                    ConsoleLog.instance.Function();
                }
                if (consoleObject.input.Contains("random"))
                {
                    int a;
                    int b;
                    string[] subs = consoleObject.input.Split(" ");
                    for (int i = 0; i < subs.Length; i++)
                    {

                    }
                    a = int.Parse(subs[1]);
                    b = int.Parse(subs[2]);
                    int r = Random.Range(a,b);
                    consoleObject.input = r.ToString();
                } 
                if (consoleObject.input.Contains("changer"))
                {
                    string[] subs = consoleObject.input.Split(" ");
                    int a;
                    float f;
                    switch (subs[1])
                    {
                        case "FPS":
                            a = int.Parse(subs[2]);
                            FPS.instance.fps = int.Parse(subs[2]);
                            consoleObject.input = "FPS = " + subs[2];
                            break;
                        case "gravityScale":
                            f = float.Parse(subs[2]);
                            stats.gs = float.Parse(subs[2]);
                            consoleObject.input = "gravityScale = " + subs[2];
                            break;
                        case "agility":
                            f = float.Parse(subs[2]);
                            stats.agillity = float.Parse(subs[2]);
                            consoleObject.input = "agility = " + subs[2];
                            break;
                        case "intelligence":
                            f = float.Parse(subs[2]);
                            stats.inteligence = float.Parse(subs[2]);
                            consoleObject.input = "intelligence = " + subs[2];
                            break;
                        case "strength":
                            f = float.Parse(subs[2]);
                            stats.strength = float.Parse(subs[2]);
                            consoleObject.input = "strength = " + subs[2];
                            break;
                        case "hp":
                            f = float.Parse(subs[2]);
                            stats.hp = float.Parse(subs[2]);
                            consoleObject.input = "hp = " + subs[2];
                            break;
                        case "mana":
                            f = float.Parse(subs[2]);
                            stats.mana = float.Parse(subs[2]);
                            consoleObject.input = "mana = " + subs[2];
                            break;
                        case "movement":
                            f = float.Parse(subs[2]);
                            movement.runSpeed = float.Parse(subs[2]);
                            consoleObject.input = "movement = " + subs[2];
                            break;
                        case "time":
                            f = float.Parse(subs[2]);
                            Time.timeScale = float.Parse(subs[2]);
                            consoleObject.input = "timeScale = " + subs[2];
                            break;
                        case "BPM":
                            f = float.Parse(subs[2]);
                            BPM.instance.songBpm = float.Parse(subs[2]);
                            BPM.instance.BPМ();
                            consoleObject.input = "sceneBpm = " + subs[2];
                            break;
                        case "immortal":
                            bool b = false;
                            b = !b;
                            stats.immortal = b;
                            break;
                    }
                }
                if (consoleObject.input.Contains("spawn"))
                {
                    ConsoleSpawn.instance.Function();
                }
            }
            catch { }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            consoleObject.input = "";
        }
    }
}