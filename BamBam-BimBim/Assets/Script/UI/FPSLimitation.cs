using UnityEngine;
using UnityEngine.UI;
public class FPSLimitation : MonoBehaviour
{
    public int target;
    public InputField valueString;
   public int check;
    void Awake()
    {
        target = PlayerPrefs.GetInt("FPStarget");
        if (check==1)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target;
        }
    }
    void Update()
    {
        if (check==1)
        {
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
                target = int.Parse(valueString.text);
        }
    }
    public void Check()
    {
        PlayerPrefs.SetInt("FPS", 1);
        check = 1;
        check = PlayerPrefs.GetInt("FPS",check);
        PlayerPrefs.SetInt("FPStarget",target);
    }
    public void Cross()
    {
        PlayerPrefs.SetInt("FPS", 0);
        check = 0;
        check = PlayerPrefs.GetInt("FPS", 0);
        PlayerPrefs.DeleteKey("FPStarget");
    }
}