using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AstronautStats : PlayerStats
{
    public PlayerStats stats;
    public bool active = true;
    public bool spel;
    public GameObject plus;
    public GameObject spawn;
    public string sceneName;
    private void Update()
    {
        moneyText.text = money.ToString();
        if (hp <= 0 && !immortal || strength<= 0 && !immortal)
        {
            SceneManager.LoadScene(sceneName);
        }
        switch (active)
        {
            case true:
                spel = true;
                break;
            case false:
                spel= false;
                break;
        }
        switch (spel && expLVL >5)
        {
            case true:
                plus.SetActive(true);
                break;
            case false:
                plus.SetActive(false);
                break;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = stats;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats))
        {
            EnemyStats.instance = null;
        }
    }
   public override void Limbus()
    {
        StartCoroutine(Reincarnation());
        gameObject.GetComponent<AstronautSpels>().enabled = false;
        gameObject.GetComponent<WASD>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerSelect>().enabled = false;
        animator.SetTrigger("Reincarnation");
        hp = maxHp;
        strength = maxHp;
    }
    public override IEnumerator Reincarnation()
    {
        yield return new WaitForSeconds(animationDelay);
        gameObject.GetComponent<PlayerSelect>().enabled = true;
        gameObject.GetComponent<AstronautSpels>().enabled = true;
        gameObject.GetComponent<WASD>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        hp = maxHp;
        strength = maxHp;
        gameObject.transform.position = spawn.transform.position;
        immortal = false;
        hp = maxHp;
        strength = maxHp;
    }
}