using UnityEngine;
using System.Collections;

public class SaveCoin : MonoBehaviour {
	string ID;
	public GameObject ficha;
	void Start(){
		ID = this.gameObject.GetInstanceID ().ToString ();
		if (!PlayerPrefs.HasKey (ID)) {
			PlayerPrefs.SetInt (ID, 1);
		}
		if (PlayerPrefs.GetInt (ID) == 0) {
			Instantiate (ficha, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

}