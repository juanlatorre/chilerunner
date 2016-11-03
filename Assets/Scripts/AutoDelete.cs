using UnityEngine;
using System.Collections;

public class AutoDelete : MonoBehaviour {

	public float delay = 1F;

	void Start () {
		Invoke ("kill", delay);
	}
	
	void kill(){
		Destroy (this.gameObject);
	}
}
