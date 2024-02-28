using UnityEngine;
public class BossMusic : MonoBehaviour
{
    public GameObject sound;
    private void OnEnable()
    {
        sound.SetActive(false);
    }
    private void OnDestroy()
    {
        sound.SetActive(true);
    }
}