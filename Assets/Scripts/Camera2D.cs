using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	Camera cam;

	void Start(){
		cam = GetComponent<Camera> ();
	}

	void FixedUpdate () {
		if (target){
			switch (target.gameObject.GetComponent<Player>().state)
			{
			case "Running":
				if (cam.orthographicSize > 14.47055F) {
					cam.orthographicSize -= Time.deltaTime * 60;
					transform.position = Vector3.Lerp (transform.position, target.position - offset, 0.5f);
				} else {
					transform.position = target.position - offset;
				}
				break;
			case "Water":
				if (cam.orthographicSize > 14.47055F) {
					cam.orthographicSize -= Time.deltaTime * 40;
					transform.position = Vector3.Lerp (transform.position, target.position - offset, 0.5f);
				} else {
					transform.position = target.position - offset;
				}
				break;
			case "Flying":
				if (target.position.y > 20) {
					transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x + 20, 6 + target.position.y - 20, -20), 0.1f);
				} else {
					transform.position = Vector3.Lerp(transform.position, new Vector3 (target.position.x + 20, 6, -20), 0.1f); 
				}
				if (cam.orthographicSize < 35F) {
					cam.orthographicSize += Time.deltaTime * 30;
				}
				break;
			}
		}
	}
}