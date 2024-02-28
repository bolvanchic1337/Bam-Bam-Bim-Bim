using KeyBinder;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GestionClickInventaire : MonoBehaviour
{
    public Manager manager;
    private bool first;
    private bool second;
    private bool third;
    private bool ult;
    private bool tab;
    private bool shift;
    private bool upArrow;
    public string[] test;
    public Text[] keyText;
    void Start()
    {
        KeyDetector.InputCheckSetActive(true);
        KeyDetector.KeyReceived += DebugKey;
        Load();
    }
    void DebugKey(KeyCode keyCode)
    {
        if (first)
        {
            manager.spels.firstSpell = KeyDetector.LatestKey;
            keyText[0].text = KeyDetector.LatestKey.ToString();
            first = false;
        }
        else if (second)
        {
            manager.spels.secondSpell = KeyDetector.LatestKey;
            keyText[1].text = KeyDetector.LatestKey.ToString();
            second = false;
        }
        else if (third)
        {
            manager.spels.ThurdSpell = KeyDetector.LatestKey;
            keyText[2].text = KeyDetector.LatestKey.ToString();
            third = false;
        }
        else if (ult)
        {
            manager.spels.ThurdSpell = KeyDetector.LatestKey;
            keyText[3].text = KeyDetector.LatestKey.ToString();
            ult = false;
        }
        else if (tab)
        {
            manager.spels.tabClick = KeyDetector.LatestKey;
            keyText[4].text = KeyDetector.LatestKey.ToString();
            tab = false;
        }
        else if (shift)
        {
            manager.wasd.shift = KeyDetector.LatestKey;
            keyText[5].text = KeyDetector.LatestKey.ToString();
            shift = false;
        }
        else if (upArrow)
        {
            manager.playerMovement.upArrow = KeyDetector.LatestKey;
            keyText[6].text = KeyDetector.LatestKey.ToString();
            upArrow = false;
        }
    }
    public void Spell0()
    {
        first = true;
    }
    public void Spell1()
    {
        second = true;
    }
    public void Spell2()
    {
        third = true;
    }
    public void Spell3()
    {
        ult = true;
    }
    public void Tab()
    {
        tab = true;
    }
    public void Shift()
    {
        shift = true;
    }
    public void UpArrow()
    {
        upArrow = true;
    }
    public void Save()
    {
        PlayerPrefs.SetString("first", keyText[0].text);
        PlayerPrefs.SetString("second", keyText[1].text);
        PlayerPrefs.SetString("third", keyText[2].text);
        PlayerPrefs.SetString("ult", keyText[3].text);
        PlayerPrefs.SetString("tab", keyText[4].text);
        PlayerPrefs.SetString("shift", keyText[5].text);
        PlayerPrefs.SetString("upArrow", keyText[6].text);
    }
    public void Load()
    {
        test[0] = PlayerPrefs.GetString("first", keyText[0].text);
        keyText[0].text = test[0];
        manager.spels.firstSpell = (KeyCode)Enum.Parse(typeof(KeyCode), test[0]);
        test[1] = PlayerPrefs.GetString("second", keyText[1].text);
        keyText[1].text = test[1];
        manager.spels.secondSpell = (KeyCode)Enum.Parse(typeof(KeyCode), test[1]);
        test[2] = PlayerPrefs.GetString("third", keyText[2].text);
        keyText[2].text = test[2];
        manager.spels.ThurdSpell = (KeyCode)Enum.Parse(typeof(KeyCode), test[2]);
        test[3] = PlayerPrefs.GetString("ult", keyText[3].text);
        keyText[3].text = test[3];
        manager.spels.UltimateSpell = (KeyCode)Enum.Parse(typeof(KeyCode), test[3]);
        test[4] = PlayerPrefs.GetString("tab", keyText[4].text);
        keyText[4].text = test[4];
        manager.spels.tabClick = (KeyCode)Enum.Parse(typeof(KeyCode), test[4]);
        test[5] = PlayerPrefs.GetString("shift", keyText[5].text);
        keyText[5].text = test[5];
        manager.wasd.shift = (KeyCode)Enum.Parse(typeof(KeyCode), test[5]);
        test[6] = PlayerPrefs.GetString("upArrow", keyText[6].text);
        keyText[6].text = test[6];
        manager.playerMovement.upArrow = (KeyCode)Enum.Parse(typeof(KeyCode), test[6]);
    }
}