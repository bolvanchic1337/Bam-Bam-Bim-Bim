using UnityEngine;
public class Guard : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    bool moveingRight;
    public Transform point;
    public PlayerStats stats;
    public Transform player;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
        }
        switch (transform.position.x <= player.position.x)
        {
            case true:
                transform.localScale = new Vector3(1, 1, -1);
                break;
            case false:
                transform.localScale = new Vector3(-1, 1, -1);
                break;
        }
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }
        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void Goback()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}