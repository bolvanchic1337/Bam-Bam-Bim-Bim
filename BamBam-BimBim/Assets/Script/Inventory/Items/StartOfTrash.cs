using UnityEngine;
using System.Collections;

public class StartOfTrash : MonoBehaviour
{
    public Base[] inctance;
    public GameObject[] trash;
    void Awake()
    {
        for (int i = 0; i < inctance.Length; i++)
        {
            inctance[i].count = inctance[i].startCount;
        }
        StartCoroutine(Trash());
    }
    IEnumerator Trash()
    {
        yield return new WaitForSeconds(2.2f);

        for (int i = 0; i < trash.Length; i++)
        {
            trash[i].SetActive(false);
        }
    }
}