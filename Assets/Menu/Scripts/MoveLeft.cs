using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	public float speed = 10;
	
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
