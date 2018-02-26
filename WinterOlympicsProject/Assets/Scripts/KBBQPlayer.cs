using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;

public class KBBQPlayer : MonoBehaviour
{
	private Player player;
	private Vector3 moveVector;
	public Chopstick chopstick1;
	public Chopstick chopstick2;

	private bool i_c1_moveLeft;
	private bool i_c1_moveRight;
	private bool i_c1_moveY;
	private bool i_detach;
	
	public int playerId = 0;

	
	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		ProcessInput();
	}

	void GetInput()
	{
		moveVector.x = player.GetAxis("Camera MoveX");
		moveVector.y = player.GetAxis("Camera MoveY");
		moveVector.z = player.GetAxis("Camera MoveZ");
		chopstick1.moveVector.x = player.GetAxis("C1_Move Horizontal");
		chopstick1.moveVector.z = player.GetAxis("C1_Move Vertical");
		chopstick2.moveVector.x = player.GetAxis("C2_Move Horizontal");
		i_detach = player.GetButtonDown("Detach");
	}

	private float myRotation = 180;
	private float c2_myRotation = 180;
	void ProcessInput()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("main");
		}

		transform.Translate(moveVector * 2.5f * Time.deltaTime);
		
		myRotation -= chopstick1.moveVector.x;
		myRotation = Mathf.Clamp (myRotation, 135f, 225f);
		chopstick1.myTransform.localRotation = Quaternion.Euler (0, 0, myRotation);
		
		c2_myRotation -= chopstick2.moveVector.x;
		c2_myRotation = Mathf.Clamp (c2_myRotation, 135f, 225f);
		chopstick2.myTransform.localRotation = Quaternion.Euler (0, 0, c2_myRotation);

		if (i_detach)
		{
			chopstick1.Detach();
			chopstick2.Detach();
		}

	}



}
