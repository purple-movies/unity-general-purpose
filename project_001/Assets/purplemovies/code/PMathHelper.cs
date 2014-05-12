namespace purplemovies
{
	using UnityEngine;
	using System.Collections;

	public class PMathHelper
	{
		public static Quaternion random( Quaternion start, Quaternion end )
		{
			Quaternion q = new Quaternion ();
			q.x = Random.Range (start.x, end.x);
			q.y = Random.Range (start.y, end.y);
			q.z = Random.Range (start.z, end.z);
			return q;
		}
		
		public static Vector3 random( Vector3 start, Vector3 end )
		{
			Vector3 v = new Vector3 ();
			v.x = Random.Range (start.x, end.x);
			v.y = Random.Range (start.y, end.y);
			v.z = Random.Range (start.z, end.z);
			return v;
		}
	}
}