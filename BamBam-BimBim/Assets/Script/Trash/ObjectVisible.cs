using UnityEngine;
public class ObjectVisible : MonoBehaviour
{
    public int charactersCount;
    public GameObject[] arcane;
    void Awake()
    {
    }
    void Update()
    {
        PlayerPrefs.GetInt("CharactersCount");
        charactersCount = PlayerPrefs.GetInt("CharactersCount");
        if (charactersCount > 0)
        {
            for (int i = 0; i < arcane.Length; i++)
            {
                arcane[i].SetActive(true);
            }
        }
    }
}