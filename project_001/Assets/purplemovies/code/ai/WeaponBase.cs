using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour
{
	/**
	 * Causes the weapon to go off randomly without having an enemy targeted.
	 */
	public bool deployRandomly = false;
	public float minTime = 0;
	public float maxTime = 3;
	
	public GameObject target;

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	
	public virtual void startAttacking ()
	{
		throw new UnityException("Not implemented.");
	}
	public virtual void startAttacking ( GameObject newTarget )
	{
		throw new UnityException("Not implemented.");
	}

	public virtual void stopAttacking ()
	{
		throw new UnityException("Not implemented.");
	}
}
