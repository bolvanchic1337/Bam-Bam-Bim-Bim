using UnityEngine;
public class xTest : MonoBehaviour
{
    public Transform player;
    private void Update()
    {
        transform.Rotate(0, 0, 0);

        switch (transform.position.x <= player.position.x)
        {
            case true:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case false:
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }
}
