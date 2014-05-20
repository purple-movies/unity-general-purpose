using UnityEngine;
using System.Collections;

public class TankShell : WeaponBase
{
	/**
	 * Where the projectile's spawned.
	 */
	public GameObject spawnPoint;
	/**
	 * An array of possible prefabs to launch.
	 */
	public GameObject[] projectiles;

	protected bool validPrefabs;
	protected Transform spawnPointTransform;

	// Use this for initialization
	void Start ()
	{
		validPrefabs = ( projectiles.Length > 0 );
		spawnPointTransform = spawnPoint.transform;
	}
	
	override public void startAttacking () {
		StartCoroutine( SPAWN_AFTER_RANDOM_TIME_COROUTINE );
	}
	override public void startAttacking ( GameObject newTarget ) {
		target = newTarget;
		StartCoroutine( SPAWN_AFTER_RANDOM_TIME_COROUTINE );
	}
	public override void stopAttacking () {
		StopCoroutine( SPAWN_AFTER_RANDOM_TIME_COROUTINE );
	}

	IEnumerator spawnAfterRandomTime ()
	{
		Debug.Log( "run :: spawnAfterRandomTime: " +validPrefabs +", " + target + ", " + deployRandomly );

		// Will FIRE if there's prefabs to deploy 
		while( validPrefabs && (target || deployRandomly) ){
			
			float waitTime = Random.Range( minTime, maxTime );
			
			yield return new WaitForSeconds( waitTime );
			var projectileGo = GameObject.Instantiate(projectiles[ 0 ], spawnPointTransform.position, spawnPointTransform.rotation ) as GameObject;
			projectileGo.GetComponent<ExplodeOnCollision>().setLauncher( gameObject );

//			explodeOnCollision.launcherGo = gameObject;
//			explodeOnCollision.explodeEnabled = true;
		}
	}
	const string SPAWN_AFTER_RANDOM_TIME_COROUTINE = "spawnAfterRandomTime";
}











