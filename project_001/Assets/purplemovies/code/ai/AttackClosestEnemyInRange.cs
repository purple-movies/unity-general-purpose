using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AttackClosestEnemyInRange : MonoBehaviour
{
	Transform targetTransform;
	Health targetHealth;
	NavMeshAgent navMeshAgent;
	List<Transform> enemiesTransformList = new List<Transform>();
	List<Transform> inRangeList = new List<Transform>();

	WeaponBase weapon;

	public GameObject enemiesGroup; 

	void Start ()
	{
		weapon = GetComponent<WeaponBase>();

		// Store reference to nav-mesh-agent:
		navMeshAgent = GetComponent<NavMeshAgent>();

		// Get all colliders initially in range of Unit:
		SphereCollider sc = collider as SphereCollider;
		Collider[] collidersInRange = Physics.OverlapSphere(sc.center, sc.radius);

		// Add all our enemies to a list & a list of any initially in range:
		Transform childTran;
		int enemyCount = enemiesGroup.transform.childCount;
		for ( int i = 0; i < enemyCount; i ++ )
		{
			childTran = enemiesGroup.transform.GetChild( i );
			enemiesTransformList.Add( childTran );

			if ( Array.IndexOf( collidersInRange, childTran.collider ) != -1 )
			{
				inRangeList.Add( childTran );
			}
		}
	}

	void OnTriggerEnter( Collider otherCollider )
	{
		// Add any enemies that enter range to the kill list :::
		Transform otherTran = otherCollider.transform;
		if ( enemiesTransformList.Contains(otherTran) && ! inRangeList.Contains( otherTran ))
		{
			inRangeList.Add( otherTran );
		}
	}
	void OnTriggerExit( Collider exitingCollider ) { // Remove any enemies going out of range from attack-list.
		inRangeList.Remove( exitingCollider.transform ); 
	}

	void FixedUpdate ()
	{
//		Debug.Log( "stuff :: " + targetHealth );

		if ( ! targetHealth )
		{
//			Debug.Log( "target died ! ");

			inRangeList.Remove( targetTransform );

			targetHealth = null;
			targetTransform = null;
		}

		// Either attack your target or pull the first target of the list to attack next !
		if ( targetTransform )
		{
			approachTarget();
		}
		// If there's no current target & there's enemies in range - start attack:
		else if ( inRangeList.Count > 0 )
		{
			targetTransform = inRangeList[ 0 ];
			targetHealth = targetTransform.GetComponent<Health>();

			Debug.Log( "in range :: " + inRangeList.Count );

			if( targetTransform )
				startAttack();
		}
	}

	void approachTarget()
	{
		// Tell nav-agent to go towards the enemy:
		navMeshAgent.SetDestination( targetTransform.position );
	}

	void startAttack ()
	{
		// Tell weapon there's a target & to start attacking it:
		weapon.startAttacking( targetTransform.gameObject );

//		Vector3 tmpAngles = transform.eulerAngles;
//		transform.LookAt( target.position );
//
//		// Limit look-at to Y rotation:
//		transform.localEulerAngles = new Vector3(
//			tmpAngles.x,
//			transform.eulerAngles.y,
//			tmpAngles.z
//		);
	}
}

















