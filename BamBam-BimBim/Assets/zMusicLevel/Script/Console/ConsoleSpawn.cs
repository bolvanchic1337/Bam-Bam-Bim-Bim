using UnityEngine;
public class ConsoleSpawn : ConsoleCommand
{
    public static ConsoleSpawn instance;
    private void Awake()
    {
        instance = this;
    }
    public override void Function()
    {
        string[] subs = ConsoleObject.instance.input.Split(" ");
        float a;
        float b;
        string c;
        a = float.Parse(subs[1]);
        b = float.Parse(subs[2]);
        c = subs[3];
        GameObject entity = GameObject.Find(c);
        Instantiate(entity, new Vector2(a, b), Quaternion.identity);
        ConsoleObject.instance.input = "Вы призвали " + c;
    }
}