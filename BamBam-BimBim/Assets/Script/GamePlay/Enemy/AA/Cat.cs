using UnityEngine;
public class Cat : MonoBehaviour
{
    public static Cat cat;
    public GameObject obj
    {
        get { return gameObject; }
    }
    void Start()
    {
        cat = this;
    }
    private void Update()
    {
        var a = new Vector3(-2f * Time.deltaTime, 0);
        transform.position +=a ;
    }
}