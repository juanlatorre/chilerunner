using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

	public Text txt;
	public static int monedas;

	void Start() {
		monedas = PlayerPrefs.GetInt("Coins");
		txt = gameObject.GetComponent<Text>();
		txt.text = monedas.ToString();	
	}
	
	void Update() {
		txt.text = PlayerPrefs.GetInt("Coins").ToString();
	}
}
