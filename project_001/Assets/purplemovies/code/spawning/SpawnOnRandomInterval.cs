using UnityEngine;
using System.Collections;

public class SpawnOnRandomInterval : SpawnOnBase
{
	public float minTime = .5f;
	public float maxTime = 3;
	
	IEnumerator spawnOn()
	{
		while ( true )
		{
			float waitTime = Random.Range( minTime, maxTime );
			yield return new WaitForSeconds( waitTime );
			spawner.spawn();
		}
	}
}
