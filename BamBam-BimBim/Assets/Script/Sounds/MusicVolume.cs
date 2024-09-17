using UnityEngine;
public class MusicVolume : MonoBehaviour
{
    public AudioSource[] music;
    private void Update()
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i] == null)
            {
                music[i] = music[i-1];
            }
            music[i].volume = PlayerPrefs.GetFloat("musicVolume");

        }
    }
}