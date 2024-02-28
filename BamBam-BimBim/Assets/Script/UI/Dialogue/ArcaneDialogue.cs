using UnityEngine;
public class ArcaneDialogue : MonoBehaviour
{
    public DialogueManager manager;
    public int state;
    public string mainText;
    public string Name;
    public string first;
    public string second;
    public GameObject objects;
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            manager.Name.text = Name;
            manager.mainText.text = mainText;
            manager.first.text = first;
            manager.second.text = second;
            objects.SetActive(true);
            state = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            objects.SetActive(false);
        }
    }
    public void First()
    {
            state++;
    }
    private void Update()
    {
        if (state == 1)
        {
            manager.mainText.text = ")";
            manager.first.text = "Заново";
            manager.second.text = "Закончить";
        }
        else if (state == 0)
        {
            manager.mainText.text = "Привет, как дела ?";
            manager.first.text = "Хорошо";
            manager.second.text = "Плохо";

        }
        else if (state == -1)
        {
            manager.mainText.text = "(";
            manager.first.text = "Заново";
            manager.second.text = "Закончить";
        }
        else if(state == 2)
        {
            state = 0;
        }
    }
    public void Second()
    {
        if (state == -1)
        {
            manager.Name.text = Name;
            manager.mainText.text = mainText;
            manager.first.text = first;
            manager.second.text = second;
            state = 0;
            objects.SetActive(false);
        }
        else if (state == 1)
        {
            objects.SetActive(false);
        }
        state--;
        mainText = "(";
        second = "Закончить?";
    }
}