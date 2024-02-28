using UnityEngine;
public class FollowMouse : MonoBehaviour
{
    public GameObject hole;
    private GameObject holePlace;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }
    private void OnMouseDown()
    {
        holePlace = Instantiate(hole, transform.position, Quaternion.identity) as GameObject;
        gameObject.SetActive(false);
        Destroy(holePlace, 0.4f);
    }

}