using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

	public Text txt;
	public static int monedas;

	void Awake() {
		monedas = PlayerPrefs.GetInt("Monedas");
	}

	void Start() {
		txt = gameObject.GetComponent<Text>();
		txt.text = "" + monedas;	
	}
	
	void Update() {
		txt.text = "" + PlayerPrefs.GetInt("Monedas");
	}
}
