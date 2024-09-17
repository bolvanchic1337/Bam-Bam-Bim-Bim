using UnityEngine;
public class CameraPralax : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        Transform transform = GetComponent<Transform>(); ;
        this.transform = transform;
    }
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if (movement > 0) transform.position += new Vector3(0.01f, 0, 0);
        if (movement < 0) transform.position += new Vector3(-0.01f, 0, 0);
    }
}