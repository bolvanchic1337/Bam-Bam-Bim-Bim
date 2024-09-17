using UnityEngine;
using UnityEngine.UI;
public class BPM : MonoBehaviour
{
    public float songBpm;
    public float secPerBeat;
    public float songPositionInBeats;
    public static BPM instance;
    public Slider slider;
    public WASD wasd;
    public int curBits;
    public Rigidbody2D rb;
    public float jumpP;
    public PlayerMovement playerMovement;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform[] m_GroundCheck;
    private bool m_Grounded;
    void OnEnable()
    {
        instance = this;
    }
    void Start()
    {
        BPÌ();
        jumpP = wasd.m_JumpForce;
    }
    void Update()
    {
        songPositionInBeats += Time.deltaTime / secPerBeat;
        slider.value = songPositionInBeats;
        if(curBits>=1)
        {
            curBits = 1;
        }
        if (songPositionInBeats >= 1)
        {
            songPositionInBeats = 0;
            curBits++;
        }
        if (Input.GetKeyDown(playerMovement.upArrow)||Input.GetKeyDown(KeyCode.Space))
        {
            if (songPositionInBeats > 0 && curBits == 1)
            {
                if (!m_Grounded)
                {
                    rb.AddForce(new Vector2(0f, jumpP));
                }
            }
            if (curBits>-1)
            {
                curBits--;
            }
        }
    }
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        for (int i = 0; i < m_GroundCheck.Length; i++)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck[i].position, 0.2f, m_WhatIsGround);
            for (int j = 0; j < colliders.Length; j++)
            {
                if (colliders[j].gameObject != gameObject)
                {
                    m_Grounded = true;
                }
                else
                {
                    m_Grounded = false;
                }
            }
        }
    }
    public void BPÌ()
    {
        secPerBeat = 60f / songBpm;
    }
}