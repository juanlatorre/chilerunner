using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	void Update () {
		transform.Rotate(Vector3.down * Time.deltaTime*350, Space.Self);
	}

}
