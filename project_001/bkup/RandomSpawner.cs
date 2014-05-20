using purplemovies;

using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

/**
 * Spawns one of the supplied Prefabs after a random time-period specified by the min/max-time parameters.
 * @param GameObject[] spawns An array of prefabs to randomly choose to spawn.
 */
public class RandomSpawner : Spawner
{
//	public List<GameObject> spawnPoints = new List<GameObject> ();

//	public GameObject[] spawns = new GameObject[1];
//	public GameObject[] spawnPoints = new GameObject[ 0 ];
//	public float minTime = .5f;
//	public float maxTime = 3;
//	public Quaternion rotationStart = new Quaternion ();
//	public Quaternion rotationEnd = new Quaternion (360, 360, 360, 0);
//	
//	private bool validPrefabs;
//	private int prefabsEndIndex = 0;
//	private int spawnPointEndIndex = 0;

	void Start ()
	{
		if( spawns.Length == 0 )
		{
			validPrefabs = false;
			Debug.LogWarning( "Spawner '"+ gameObject.name +"' doesn't have any prefabs assigned to spawn!" );
		}
		else
		{
			validPrefabs = true;
			prefabsEndIndex = spawns.Length;
			spawnPointEndIndex = spawns.Length;
			System.Array.Resize( ref spawnPoints, spawnPointEndIndex );
			spawnPoints[ spawnPointEndIndex - 1 ] = gameObject;
//			spawnPoints.Add( gameObject );
		}
//		StartCoroutine( spawnAfterRandomTime() );
	}

	public GameObject spawn()
	{
		Vector3 spawnPosition = spawnPoints[ Random.Range(0, spawnPointEndIndex) ].transform.position;
		int i = Random.Range( 0, prefabsEndIndex );
		Quaternion randomRotation = PMathHelper.random( rotationStart, rotationEnd );
		return GameObject.Instantiate(spawns[ i ], spawnPosition, randomRotation ) as GameObject;
	}
	
	IEnumerator spawnAfterRandomTime()
	{
		while ( validPrefabs )
		{
			float waitTime = Random.Range( minTime, maxTime );
			yield return new WaitForSeconds( waitTime );

			Vector3 spawnPosition = spawnPoints[ Random.Range(0, spawnPointEndIndex) ].transform.position;
			int i = Random.Range( 0, prefabsEndIndex );
			Quaternion randomRotation = PMathHelper.random( rotationStart, rotationEnd );
			GameObject.Instantiate(spawns[ i ], spawnPosition, randomRotation );
		}
	}
}