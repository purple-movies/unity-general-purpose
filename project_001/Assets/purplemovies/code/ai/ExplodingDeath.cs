using UnityEngine;
using System.Collections;

public class ExplodingDeath : DeathBehaviour {

	public GameObject explosionPrefab;

	public override void kill ()
	{
		Instantiate( explosionPrefab, transform.position, transform.rotation );
		Destroy( gameObject );
	}


//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
