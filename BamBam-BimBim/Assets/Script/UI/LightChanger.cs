using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class LightChanger : MonoBehaviour
{
    public Slider slider;
    public Light2D light2d;
    public Image image;
    public Sprite[] sprite;
    private void Update()
    {
        light2d.intensity = slider.value;
        if(slider.value > 1)
        {
            image.sprite = sprite[0];
        }
        else if(slider.value < 1)
        {
            image.sprite = sprite[1];
        }
        else
        {
            image.sprite = sprite[0];
        }
    }
}