using UnityEngine;
using System.Collections;

public class CollisionHealthAffecter : MonoBehaviour
{
	bool thereIsACollider = false;
	Health health;

	public float damageAffect = 0;

	// Use this for initialization
	void Start ()
	{
		health = GetComponent<Health>();
		thereIsACollider = ( collider != null );

		if( thereIsACollider ){
			collider.isTrigger = true;
		}
		else{
			Debug.LogWarning( "Health won't be affected - no collider for CollisionHealthAffecter.");
		}

		if( ! health ) {
			Debug.LogWarning( "Health won't be affected - no Health component for CollisionHealthAffecter.");
		}
	}

	void OnTriggerEnter( Collider col )
	{
//		Debug.Log( "colliding !!!!!!!!!!!!!!!!!! " );
		health.takeDamage( damageAffect );
	}
	


//	// Update is called once per frame
//	void FixedUpdate ()
//	{
//		if ( thereIsACollider )
//		{
//
//		}
//	}
}
