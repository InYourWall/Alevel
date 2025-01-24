using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


	public float moveSpeed;
	private Vector2 moveInput;
	public Rigidbody2D rb2d;

	private float activeMoveSpeed;
	public float dashSpeed;

	public float dashLength = .5f, dashCooldown = 1f;

	private float dashCounter;
	private float dashCoolCounter;


	// Use this for initialization
	void Start () {
		
		activeMoveSpeed = moveSpeed;

	}
	
	// Update is called once per frame
	void Update () {

		moveInput.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
		moveInput.y = Input.GetAxisRaw("Vertical") * moveSpeed;
		
		moveInput.Normalize();

		rb2d.linearVelocity = moveInput * activeMoveSpeed;

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (dashCoolCounter <=0 && dashCounter <= 0)
			{
				activeMoveSpeed = dashSpeed;
				dashCounter = dashLength;
			}
		}

		if (dashCounter > 0)
		{
			dashCounter -= Time.deltaTime;

			if (dashCounter <= 0)
			{
				activeMoveSpeed = moveSpeed;
				dashCoolCounter = dashCooldown;
			}
		}

		if (dashCoolCounter > 0)
		{
			dashCoolCounter -= Time.deltaTime;
		}

		
	}
}