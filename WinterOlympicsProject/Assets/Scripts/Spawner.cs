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
				if (KBBQPlayer.instance.player.GetButtonDown("Spawn Meat"))
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
//				SpawnGameobject("lettuce", transform.position);
				break;	
			default:
				break;
			
		}


	}

	public void SpawnGameobject(string objToLoad, Vector3 pos){
		GameObject spawned = Instantiate(Resources.Load("Prefabs/" + objToLoad), pos, Quaternion.identity) as GameObject;
		// cloud.transform.localScale = new Vector3(Random.Range (3,10), Random.Range(3,10), Random.Range(3,10));
		// cloud.transform.eulerAngles = new Vector3(0, Random.Range(0,359), 0);
 	}

	public IEnumerator DelayedSpawn(string objToLoad, float spawnDelay)
	{
		yield return new WaitForSeconds(spawnDelay);
		Debug.Log("Spawning new lettuce");
		GameObject spawned = Instantiate(Resources.Load("Prefabs/" + objToLoad), transform.position, Quaternion.identity) as GameObject;

	}
}
