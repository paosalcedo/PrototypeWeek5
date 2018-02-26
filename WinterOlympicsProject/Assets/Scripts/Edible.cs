﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour
{

	public Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		Utils.RandomizeRotation(Vector3.right, Random.Range(0, 360), this.transform);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.GetComponentInParent<Chopstick>() != null && coll.gameObject.GetComponent<Edible>() == null)
		{
			if (!coll.gameObject.GetComponentInParent<Chopstick>().hasPickedUpEdible)
			{
				GetComponent<Rigidbody>().isKinematic = true;
				Debug.Log("Collided with a chopstick!");
				this.transform.SetParent(coll.gameObject.transform);
				coll.gameObject.GetComponentInParent<Chopstick>().hasPickedUpEdible = true;				
			}

//			Debug.Log("Collided with a chopstick!");
//			this.gameObject.AddComponent<FixedJoint>();
//			Debug.Log(GetComponent<FixedJoint>().breakForce);
//			GetComponent<FixedJoint>().connectedBody = coll.gameObject.GetComponent<Rigidbody>();
		}
	}

	void OnTriggerStay(Collider trigger)
	{
	}
	
}
