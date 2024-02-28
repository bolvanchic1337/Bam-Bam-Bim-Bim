using UnityEngine;
using UnityEngine.UI;
public class MusicCharacteristics : MonoBehaviour
{
    public Slider slider;
        private void Update()
    {
            PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
}