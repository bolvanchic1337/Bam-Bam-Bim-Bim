using UnityEngine;
public class ActualRotator : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        gameObject.transform.eulerAngles = Vector3.zero;
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector2(-2,2);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(2, 2);
        }
    }
}