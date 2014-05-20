using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public float level = 1000f;
	DeathBehaviour deathBehavior;

	void Start()
	{
		deathBehavior = GetComponent<DeathBehaviour>();
		if( ! deathBehavior )
			Debug.LogWarning( "Health does not have access to a DeathBehaviour component - unit with never dye (health will just become negitive)." );
	}

	public float takeDamage( float val )
	{
		level -= val;
		Debug.Log( "health points : " + level );

		if( ! isAlive() && deathBehavior )
			deathBehavior.kill();

		return level;
	}

	public bool isAlive()
	{
		if ( level > 0 )
			return true;
		return false;
	}

	public bool isDead()
	{
		return ! this.isAlive();
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
