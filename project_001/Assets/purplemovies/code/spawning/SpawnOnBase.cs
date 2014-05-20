using UnityEngine;
using System.Collections;

public class SpawnOnBase : MonoBehaviour
{
	public bool autoStart = false;

	protected Spawner spawner;
	protected const string SPAWN_ON = "spawnOn";

	// Use this for initialization
	protected void Start ()
	{
		spawner = GetComponent<Spawner>();
		if ( ! spawner )
			Debug.LogError( "A spawn-on behaviour requires a Spawner base component attached to the game-object - not found!" );

		if( autoStart )
			startSpawning();
	}
	
	public void startSpawning() {
		StartCoroutine( SPAWN_ON );
	}
	public void stopSpawning() {
		StopCoroutine( SPAWN_ON );
	}

	IEnumerator spawnOn() {
		Debug.LogWarning( "startSpawning() is not implemented on a sub-class - abstract super-method was called." );
		yield return null; 
	}
}
