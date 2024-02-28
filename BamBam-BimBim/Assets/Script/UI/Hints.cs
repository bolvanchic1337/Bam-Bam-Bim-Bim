using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    public GameObject hint;
    public string hintString;
    public Text hintText;
    public void A()
    {
        hint.SetActive(true);
        hintText.text = hintString;
    }
    public void B()
    {
        hint.SetActive(false);
    }
}