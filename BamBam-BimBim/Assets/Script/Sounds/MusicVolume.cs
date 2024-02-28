using UnityEngine;
public class MusicVolume : MonoBehaviour
{
    public AudioSource[] music;
    private void Update()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }
}