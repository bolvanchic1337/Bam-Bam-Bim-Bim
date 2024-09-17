using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {
	public WASD controller;
    public Text movementText;
	public Manager manager;
    public float runSpeed = 40f;
	public KeyCode upArrow = KeyCode.UpArrow;
	float horizontalMove = 0f;
	public bool jump = false;
	public Animator animator;
	void Update () 
	{
        manager.playerMovement.movementText.text = manager.playerMovement.runSpeed.ToString();
        animator.SetFloat("Walk", Mathf.Abs(horizontalMove));
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump") || Input.GetKeyDown(upArrow))
		{
			jump = true;
		}
	}
    void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}