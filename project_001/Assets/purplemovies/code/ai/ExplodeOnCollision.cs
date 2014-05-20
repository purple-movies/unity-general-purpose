using UnityEngine;
using System.Collections;
using System.Linq;

public class ExplodeOnCollision : MonoBehaviour
{
	public GameObject explosionPrefab;
//	public GameObject[] ignoreList;
	
	bool explodeEnabled = false;
	GameObject launcherGo;

	public void setLauncher( GameObject go )
	{
		launcherGo = go;
		explodeEnabled = true;
	}

	void Start ()
	{
		if( ! explosionPrefab )
			Debug.LogWarning( "No explosion prefab for ExplodeOnCollision to use." );
	}
	void OnTriggerEnter( Collider col )
	{
//		Debug.Log( "colliding :: " + col.gameObject.name );

//		if( col.gameObject.name != "Unit" )
		if( explodeEnabled && col.gameObject != launcherGo )
		{
			GameObject.Destroy ( gameObject );
			GameObject.Instantiate( explosionPrefab, transform.position, transform.rotation );
		}
	}
}
