using UnityEngine;
using System.Collections;

public class Recycler : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;
	
	void Update () {
		if (transform.position.x < endPoint.position.x) {
			float gap = endPoint.position.x - transform.position.x;
			transform.position = new Vector3(startPoint.position.x - gap, transform.position.y, transform.position.z);
		}	
	}
}
