public class ConsoleLog : ConsoleCommand
{
    public static ConsoleLog instance;
    private void Awake()
    {
        instance = this;
    }
    public override void Function()
    {
        string[] subs = ConsoleObject.instance.input.Split(" ");
        switch (subs[1])
        {
            case "time":
                ConsoleObject.instance.input = System.DateTime.Now.ToString();
                break;
            case "FPS":
                ConsoleObject.instance.input = UnityEngine.Application.targetFrameRate.ToString();
                break;
            case "dataPath":
                ConsoleObject.instance.input = UnityEngine.Application.dataPath;
                break;
            case "identifier":
                ConsoleObject.instance.input = UnityEngine.Application.identifier;
                break;
            case "company":
                ConsoleObject.instance.input = UnityEngine.Application.companyName;
                break;
            case "platform":
                ConsoleObject.instance.input = UnityEngine.Application.platform.ToString();
                break;
            case "timeScale":
                ConsoleObject.instance.input = UnityEngine.Time.timeScale.ToString();
                break;
        }
    }
}