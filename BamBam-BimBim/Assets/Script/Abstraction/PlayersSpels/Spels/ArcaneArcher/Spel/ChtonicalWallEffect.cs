using UnityEngine;
public class ChtonicalWallEffect : MonoBehaviour
{
    public float GradientSpeed = 0.1f;
    [SerializeField]
    private Gradient _gradient;
    [SerializeField]
    private float _gradientTime = 0;
    [SerializeField]
    private Transform player;
    private SpriteRenderer _spriteRend;
    public ArcaneArrows arrows;
    private void OnEnable()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        transform.position = player.position;
    }
    void Update()
    {
        _gradientTime += GradientSpeed * Time.deltaTime;
        _gradientTime %= 1f;
        _spriteRend.color = _gradient.Evaluate(_gradientTime);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(21, 0);
        }
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats EnemyStats) && other.gameObject.name != "ArcaneArcher")
        {
            EnemyStats.instance = arrows.stats;
            EnemyStats.Damage("magical",arrows.arrows);
        }
    }
}