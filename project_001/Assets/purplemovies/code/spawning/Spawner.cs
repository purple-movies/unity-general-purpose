using purplemovies;

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject[] spawnPrefabs = new GameObject[1];
	public GameObject[] spawnPoints = new GameObject[ 0 ];
//	public float minTime = .5f;
//	public float maxTime = 3;
	public Quaternion rotationStart = new Quaternion ();
	public Quaternion rotationEnd = new Quaternion (360, 360, 360, 0);
	
	protected bool validPrefabs;
	protected int currentPrefabIndex = 0;
	protected int currentSpawnPointIndex = 0;
	
	/**
	 * Spawns & returns a game-object.
	 */
	public GameObject spawn()
	{
		return GameObject.Instantiate( spawnPrefabs[ currentPrefabIndex ] ) as GameObject;
	}
	/**
	 * Spawns & returns a game-object.
	 * @param int prefabIndex The index in the spawnPrefabs array.
	 */
	public GameObject spawn( int prefabIndex )
	{
		currentPrefabIndex = prefabIndex;
		return spawn();
	}
	
	void Start ()
	{
		if( spawnPrefabs.Length == 0 )
		{
			validPrefabs = false;
			Debug.LogWarning( "Spawner '"+ gameObject.name +"' doesn't have any prefabs assigned to spawn!" );
		}
		else {
			var spLen = spawnPoints.Length;

			validPrefabs = true;
			currentPrefabIndex = spawnPrefabs.Length - 1;
			currentSpawnPointIndex = spLen - 1;
			System.Array.Resize( ref spawnPoints, spLen + 1 );
			spawnPoints[ spLen ] = gameObject;
		}
	}
}
