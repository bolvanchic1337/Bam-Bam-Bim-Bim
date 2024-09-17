using UnityEngine;
public class FPS : MonoBehaviour
{
    public static FPS instance;
    private void Awake()
    {
        instance = this;
    }
    public int fps = 60;
    void Update()
    {
        if (Application.targetFrameRate != fps)
            Application.targetFrameRate = fps;
    }
}