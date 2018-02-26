using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour
{
	[SerializeField] private GameObject[] plates;
	[SerializeField] private AudioClip[] clips;

	public AudioSource myAudioSource;
	// Use this for initialization
	public Transform myTransform;
	private AudioManager audioManager;
 	public MeatState meatState;

	[SerializeField] private MeshRenderer[] meatRenderers;

	public bool isDipped = false;

	[SerializeField]private float timeOnGrill = 0;

	
	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start ()
	{
		audioManager = FindObjectOfType<AudioManager>();
		myAudioSource = GetComponent<AudioSource>();
// 		myAudioSource.time = Random.Range(0.00001f, 22.84301f);
		myAudioSource.PlayScheduled(AudioSettings.dspTime + 0.0000001f);
		isDipped = false;
		meatState = MeatState.Raw;
		Utils.RandomizeRotation(Vector3.right, Random.Range(0, 360), this.transform);	
	}
	
	// Update is called once per frame
	void Update () {
		switch (meatState)
		{
			case MeatState.Raw:
				if (timeOnGrill >= 10f && timeOnGrill < 20f)
				{
					GetComponent<MeshRenderer>().enabled = false;
					meatState = MeatState.Cooked;
				}

				break;
			case MeatState.Cooked:
				meatRenderers[0].enabled = true;
				if (timeOnGrill >= 20f && timeOnGrill < 30f)
				{
					meatRenderers[0].enabled = false;
					meatState = MeatState.Burned;					
				}
				break;
			case MeatState.Burned:
				meatRenderers[1].enabled = true;
				if (timeOnGrill >= 30f)
				{
//					Destroy(gameObject);	
				}
				break;
			default:
				break;
		}

		if (isDipped)
		{
			GetComponent<MeshRenderer>().enabled = false;
			meatRenderers[0].enabled = false;
			meatRenderers[1].enabled = false;
			meatRenderers[2].enabled = true;
		}

		if (transform.position.y <= -20f)
		{
			Destroy(gameObject);
		}

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
		//cooking on grill
		if (trigger.gameObject.layer == 10)
		{
			timeOnGrill += Time.deltaTime;
			myAudioSource.volume = 0.5f;
		} else if (trigger.gameObject.layer == 11)
		{
			isDipped = true;
		}
	}

	private void OnTriggerExit(Collider trigger)
	{
		if (trigger.gameObject.layer == 10)
		{
			myAudioSource.volume = 0;
		}
	}

	private void OnTriggerEnter(Collider trigger)
	{
		if (trigger.gameObject.layer == 12) //goal
		{
			switch (meatState)
			{
				case MeatState.Raw:
					Destroy(gameObject);
					Destroy(trigger.gameObject.transform.parent.gameObject);
					break;
				case MeatState.Cooked:
					Destroy(gameObject);
					Destroy(trigger.gameObject.transform.parent.gameObject);
					break;
				case MeatState.Burned:
					Destroy(gameObject);
					Destroy(trigger.gameObject.transform.parent.gameObject);
					break;
				default:
					break;
			}

		}
	}

	void OnDestroy()
	{ 
		switch (meatState)
		{
			case MeatState.Raw:	
				audioManager.PlayDisgustedSound();
				break;
			case MeatState.Cooked:
				if(isDipped)
					audioManager.PlayDelishSound();			
				break;
			case MeatState.Burned:
				audioManager.PlayDisgustedSound();
				break;
			default:
				break;
		}
	}
}
