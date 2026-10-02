using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		float moveInput = 0f;

		// Memeriksa input Keyboard (A/D atau Panah Kiri/Kanan)
		if (Keyboard.current != null)
		{
			if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
				moveInput = -1f;
			if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
				moveInput = 1f;

			// Tombol Lompat (Spasi)
			if (Keyboard.current.spaceKey.wasPressedThisFrame)
			{
				jump = true;
			}

			// Tombol Menunduk / Crouch (Tombol S atau Panah Bawah)
			if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
			{
				crouch = true;
			} 
			else if (Keyboard.current.sKey.wasReleasedThisFrame || Keyboard.current.downArrowKey.wasReleasedThisFrame)
			{
				crouch = false;
			}
		}

		horizontalMove = moveInput * runSpeed;

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}