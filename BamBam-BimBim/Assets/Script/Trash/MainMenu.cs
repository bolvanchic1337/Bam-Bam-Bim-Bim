using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class MainMenu : MonoBehaviour
{
    public Toggle toggleCollider;
    public Toggle toggleMouse;
    public Toggle toggleMode;
    public int shopCollider;
    public int shopOnMouse;
    public int normalMode;
    public void Awake()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            shopCollider = PlayerPrefs.GetInt("shopCollider",1);
            shopOnMouse = PlayerPrefs.GetInt("shopOnMouse",1);
            normalMode = PlayerPrefs.GetInt("normalMode",1);
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        }
        else
        {
            shopCollider = PlayerPrefs.GetInt("shopCollider");
            shopOnMouse = PlayerPrefs.GetInt("shopOnMouse");
            normalMode = PlayerPrefs.GetInt("normalMode");
        }
        if (shopCollider == 0)
        {
            toggleCollider.isOn = false;
        }
        if (shopOnMouse == 0)
        {
            toggleMouse.isOn = false;
        }
        switch (normalMode == 0)
        {
            case true:
                toggleMode.isOn = false;
                break;
        }
    }
    private void Update()
    {
        shopCollider = Convert.ToInt32(toggleCollider.isOn);
        shopOnMouse = Convert.ToInt32(toggleMouse.isOn);
        normalMode = Convert.ToInt32(toggleMode.isOn);
        PlayerPrefs.SetInt("shopCollider", shopCollider);
        PlayerPrefs.SetInt("shopOnMouse", shopOnMouse);
        PlayerPrefs.SetInt("normalMode", normalMode);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Score()
    {
        SceneManager.LoadScene("ScoreBalance");
    }
    public void ScoreArcane()
    {
        SceneManager.LoadScene("ScoreArcane");
    }
    public void StoryBalance()
    {
        SceneManager.LoadScene("StoryBalance");
    }
    public void Test(string a)
    {
        SceneManager.LoadScene(a);
    }
}