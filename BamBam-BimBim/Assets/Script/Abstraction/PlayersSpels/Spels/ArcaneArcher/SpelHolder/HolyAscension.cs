using UnityEngine;
public class HolyAscension : Spell
{
    public GameObject top;
    public WASD jump;
    public PlayerMovement move;
    public void Cast()
    {
        jump.m_JumpForce = 5000;
        if(jump.m_JumpForce == 5000)
        {
            move.runSpeed += 10;
        }
        top.SetActive(true);
        gameObject.SetActive(false);
    }
}