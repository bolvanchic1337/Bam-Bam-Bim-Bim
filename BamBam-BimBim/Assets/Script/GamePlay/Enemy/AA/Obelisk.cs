using UnityEngine;
public class Obelisk : MonoBehaviour
{
    private float timer = 7.5f;
    private float aTimer = 10;
    private float curATimer = 10;
    private float curTimer = 7.5f;
    public objectsStats[] stats;
    bool a;
    public SpriteRenderer spriteRenderer;
    public GameObject phylactery;
    void Update()
    {
        if (a)
        {
            spriteRenderer.enabled = true;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = curTimer;
                for (int i = 0; i < stats.Length; i++)
                {
                    stats[i].LvlUp();
                }
            }
        }
        else if(!a)
        {
            timer = 7.5f;
            curTimer = 7.5f;
            spriteRenderer.enabled = false;
            aTimer -= Time.deltaTime;
            if (aTimer <= 0)
            {
                aTimer = curATimer;
                a = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            a = false;
        }
        switch (collision.tag == "Finish")
        {
            case true:
                phylactery.transform.position = transform.position;
                Destroy(gameObject);
                break;
        }
    }
}