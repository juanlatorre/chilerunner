using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	void Start(){
		Invoke ("nextScene", 6);
	}

	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime*120, Space.Self);
	}

	void nextScene(){
		SceneManager.LoadScene (2);
	}
}
