using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
//		rigidbody.AddRelativeForce (new Vector3( 0f, 0f, 1000f ));
		rigidbody.AddRelativeForce (new Vector3( 0f, 3000f, 0f ));
//		rigidbody.AddRelativeForce (new Vector3( 1000f, 0f, 0f ));
//		rigidbody.velocity = new Vector3( 0f, 0f, 1000f);
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
