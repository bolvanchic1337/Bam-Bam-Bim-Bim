public class ConsoleCalculations : ConsoleCommand
{
    public static ConsoleCalculations instance;
    private void Awake()
    {
        instance = this;
    }
    public override void Function()
    {
        int a;
        int b;
        string[] subs = ConsoleObject.instance.input.Split(" ");
        a = int.Parse(subs[1]);
        b = int.Parse(subs[2]);
        int r = a + b;
        ConsoleObject.instance.input = r.ToString();
    }
    public  void Function1()
    {
        int a;
        int b;
        string[] subs = ConsoleObject.instance.input.Split(" ");
        a = int.Parse(subs[1]);
        b = int.Parse(subs[2]);
        int r = a - b;
        ConsoleObject.instance.input = r.ToString();
    }
    public  void Function2()
    {
        int a;
        int b;
        string[] subs = ConsoleObject.instance.input.Split(" ");
        a = int.Parse(subs[1]);
        b = int.Parse(subs[2]);
        int r = a / b;
        ConsoleObject.instance.input = r.ToString();
    }
    public  void Function3()
    {
        int a;
        int b;
        string[] subs = ConsoleObject.instance.input.Split(" ");
        a = int.Parse(subs[1]);
        b = int.Parse(subs[2]);
        int r = a * b;
        ConsoleObject.instance.input = r.ToString();
    }
}