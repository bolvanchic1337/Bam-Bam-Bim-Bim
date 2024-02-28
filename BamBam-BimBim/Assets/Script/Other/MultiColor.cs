using UnityEngine;
using UnityEngine.UI;
public class MultiColor : MonoBehaviour
{
    public Slider[] slider;
    public SpriteRenderer[] sprite;
    public TrailRenderer trailRenderer;
        
    private void Start()
    {
        slider[0].value = 1;
        slider[1].value = 1;
        slider[2].value = 1;
    }
    private void Update()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = new Color(slider[0].value, slider[1].value, slider[2].value);
            trailRenderer.startColor = new Color(slider[0].value, slider[1].value, slider[2].value);
        }
    }
}