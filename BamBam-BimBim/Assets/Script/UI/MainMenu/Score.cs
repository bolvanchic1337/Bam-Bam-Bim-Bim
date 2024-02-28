using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public PlayerStats stats;
    public float score;
    public string scoreString;
    private void Awake()
    {
        PlayerPrefs.GetFloat(scoreString, score);
    }
    void Update()
    {
        switch (stats.money > score)
        {
            case true:
                score = stats.money;
                PlayerPrefs.SetFloat(scoreString, score);
                score = PlayerPrefs.GetFloat(scoreString, score);
                break;
        }
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
