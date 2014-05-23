using UnityEngine;
using System.Collections;

public class WalkTest : MonoBehaviour {

	public GameObject ToPoint;

	public bool testLayer = false;

	NavMeshAgent myAgent;

	const float NORMAL_SPEED = 4;
	
	int defaultLayer;
	int muddyGroundLayer;

	// Use this for initialization
	void Start ()
	{
		myAgent = GetComponent<NavMeshAgent>();
		myAgent.SetDestination( ToPoint.transform.position );

//		Debug.Log( "name: " + myAgent.pathStatus + ", layer cost: " + myAgent.GetLayerCost (1) );

//		int meshLayer = 1 << NavMesh.GetNavMeshLayerFromName ("Muddy Ground");
		//Debug.Log( "nml : " + meshLayer); 
		
		defaultLayer = 1<<NavMesh.GetNavMeshLayerFromName ("Default");
		muddyGroundLayer = 1<<NavMesh.GetNavMeshLayerFromName ("Muddy Ground");
//		muddyGroundLayer = NavMesh.GetNavMeshLayerFromName ("Muddy Ground");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( testLayer ) 
		{
//			int muddyGroundLayer = 1<<NavMesh.GetNavMeshLayerFromName ("Muddy Ground");
			
			NavMeshHit hit;
			
			myAgent.SamplePathPosition (-1, 0.0f, out hit);

			Debug.Log( "stuff : " + hit.mask + " & " + defaultLayer );

			if( hit.mask == defaultLayer ) {
				Debug.Log( "default layer" );
				myAgent.speed = 2;
			}
			else if( hit.mask == muddyGroundLayer ) {
				Debug.Log( "muddy layer" );
				myAgent.speed = 1.7f;
			}

//			switch( hit.mask )
//			{
//			case defaultLayer :
//				Debug.Log( "default layer" );
//				break;
//			case muddyGroundLayer:
//				Debug.Log( "muddy layer" );
//				break;
//			}

//			if ( (hit.mask & muddyGroundLayer) != 0)
//				
//				Debug.Log ("Swimming");
//			else
//				Debug.Log ("Walking");


//			NavMeshHit hit;
//
//			if( ! myAgent.SamplePathPosition( -1, 0F, out hit ) )
//			{
//				if( (hit.mask & muddyGroundLayer) != 0 )
//				{
//					Debug.Log( "on muddy ground !! " );
//				}
//			}

//			Debug.Log( "hit : " + myAgent.GetLayerCost( hit.mask ) );
		}
	}
}
