using UnityEngine;
using System.Collections;

public class DeathBehaviour : MonoBehaviour {

	public virtual void kill ()
	{
		throw new UnityException("Not implemented.");
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
