using UnityEngine;
public class testmath : MonoBehaviour
{
    public float speed;
    public float radius;
    float value;
    public GameObject a;
    public GameObject a1;
   public bool o = false;
    public bool l = false;
    public Rigidbody2D rb;
    public float plus;
    public string plusStr;
    private void Start()
    {
        transform.position = a.transform.position;
    }
    void Update()
    {
        float amplitude = 0.5f;
        float amplitudeOffset = 0.5f;
        float ySpeed = 25f;
        float yAmplitude = 2;
        plus -=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            o = true;
            l = false;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            o = false;
            l = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            o = false;
            l = false;
        }
        switch (o)
        {
            case true:
                value -= Time.deltaTime * speed;
                float x = Mathf.Sin(value) * radius;
                float y = Mathf.Cos(value) * radius;
                transform.position = new Vector3(x, y, -1) + a.transform.position;
                break;
        }
        switch (l)
        {
            case true:
                rb.velocity = new Vector2(transform.localScale.x + speed, 0f);
                break;
        }
        switch (plus<=0)
        {
            case true:
                plus = 3;
                speed *= -1;
                break;
        }
        switch (speed <= 0)
        {
            case true:
                plusStr = "-";
                break;
            case false: plusStr = "+";break;
        }
        switch (!o && !l)
        {
            case true:
                var Yoffset = new Vector3(0,Mathf.Sin(Time.time * ySpeed)* yAmplitude +yAmplitude,-1);
                transform.position = Vector3.Lerp(a.transform.position + Yoffset, a1.transform.position +Yoffset, Mathf.Sin(Time.time * speed) * amplitude + amplitudeOffset);
                break;
        }
    }
}