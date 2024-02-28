using UnityEngine;
using UnityEngine.UI;
public class FpsController : MonoBehaviour
{
    public Text fpsText;
    private float deltaTime;
    public int check;
    public int target;
    void Awake()
    {
        check = PlayerPrefs.GetInt("FPS");
        target = PlayerPrefs.GetInt("FPStarget");
        if (check == 1)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target;
        }
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
        if (check == 1)
        {
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
        }
    }
}