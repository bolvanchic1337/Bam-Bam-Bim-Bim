using UnityEngine;
public class ClickOnCharacter : MonoBehaviour
{
    public PlayerSelect playerSelect;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {

        }
    }
    public void SimulateClick()
    {
        playerSelect.Next();

    }
}
