using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopstick : MonoBehaviour
{

	public Transform myTransform;
	public Collider myCollider;
	public Vector3 moveVector;

	void Awake()
	{
		myCollider = GetComponentInChildren<Collider>();
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
}
