using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopstick : MonoBehaviour
{
	public bool hasPickedUpEdible = false;
	public Transform myTransform;
	public Collider myCollider;
	public Vector3 moveVector;
	public GameObject myChopstickGO;
	
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

	public void Detach()
	{
//		if (hasPickedUpEdible)
//		{
			for (var i = 0; i < myChopstickGO.transform.childCount; ++i)
			{
				myChopstickGO.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
				Rigidbody edibleRb = myChopstickGO.transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
				edibleRb.useGravity = true;
				myChopstickGO.transform.GetChild(i).SetParent(null);
//				hasPickedUpEdible = false;
				StartCoroutine(SetBoolToFalse(edibleRb));
			}
//		}
	}

	IEnumerator SetBoolToFalse(Rigidbody rb)
	{
		yield return new WaitForSeconds(0.1f );
//		someBool = false;
		rb.isKinematic = false;
		hasPickedUpEdible = false;
		Debug.Log("set bool to false!");
	}

	
}
