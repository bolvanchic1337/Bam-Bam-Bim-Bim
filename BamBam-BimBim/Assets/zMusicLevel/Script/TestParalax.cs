using UnityEngine;
public class TestParalax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrenght = 0.1f;
    [SerializeField] float z;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;
    void Start()
    {
        targetPreviousPosition = followingTarget.position;
    }
    void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;
        if (disableVerticalParallax) delta.y = 0;
        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxStrenght;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}