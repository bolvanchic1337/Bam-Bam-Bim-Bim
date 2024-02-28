using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class WASD : MonoBehaviour
{
    public WASD instance;
    [SerializeField] public float m_JumpForce = 400f;                          
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform[] m_GroundCheck;                           // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; 
    private bool m_Grounded;            // Whether or not the player is grounded.
    public Rigidbody2D rb;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;
    public TrailRenderer tr;
    private bool canDash =true;
    private bool isDashing;
    public Vector3 theScale;
    public UnityEvent m_MyEvent;
    public KeyCode shift = KeyCode.LeftShift;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        for (int i = 0; i < m_GroundCheck.Length; i++)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck[i].position, k_GroundedRadius, m_WhatIsGround);
            for (int j = 0; j < colliders.Length; j++)
            {
                if (colliders[j].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        m_MyEvent.Invoke();
                }
            }

        }

        if (isDashing)
        {
            return;
        }
        switch(Input.GetKey(shift) && canDash)
        {
            case true:
                StartCoroutine(Dash());
                    break;
        }
    }
    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        if (move > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (move < 0 && m_FacingRight)
        {
            Flip();
        }
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            rb.AddForce(new Vector2(0f, m_JumpForce));
        }
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * 75, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(0.3f);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(0.3f);
        canDash = true;
    }
}