using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

 	public float multiplier = 0;
	public float timer;
	public float timerMax;

	public enum ObjectToSpawn
	{
		Lettuce,
		Meat
	}

	public ObjectToSpawn objectToSpawn;
	// Use this for initialization
	public void Start () {
		timer = Random.Range(0.1f, 1);
		timerMax = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	public void Update () {
		switch (objectToSpawn)
		{
			case ObjectToSpawn.Meat:
				if (Input.GetKey(KeyCode.Space))
				{
					SpawnGameobject("meatcomplete", transform.position);					
				}

//				timer -= Time.deltaTime;
//				if(timer <= 0){
//					SpawnGameobject("meatcomplete", transform.position);
//					timer = Random.Range(1,3);
//				}
				break;
			case ObjectToSpawn.Lettuce:
				timer -= Time.deltaTime;
				if(timer <= 0){
					SpawnGameobject("lettuce", transform.position);
					timer = Random.Range(1,3);
				}
				break;	
			default:
				break;
			
		}


	}

	public virtual void SpawnGameobject(string objToLoad, Vector3 pos){
		GameObject spawned = Instantiate(Resources.Load("Prefabs/" + objToLoad), pos, Quaternion.identity) as GameObject;
		// cloud.transform.localScale = new Vector3(Random.Range (3,10), Random.Range(3,10), Random.Range(3,10));
		// cloud.transform.eulerAngles = new Vector3(0, Random.Range(0,359), 0);
 	}
}
