using UnityEngine;
using UnityEngine.SceneManagement;
public class Chalanhe : MonoBehaviour
{
    public Transform player;
    public Transform spawn;
    public void Chalange()
    {
        SceneManager.LoadScene("ScoreBalance");
    }
    public void Spawn()
    {
        player.position = spawn.position;
    }
}