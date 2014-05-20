using UnityEngine;
using System.Collections;

public class SpawnOnInterval : SpawnOnBase
{
	public float interval = 1;

	IEnumerator spawnOn()
	{
		while ( true )
		{
			yield return new WaitForSeconds( interval );
			spawner.spawn();
		}
	}
}
