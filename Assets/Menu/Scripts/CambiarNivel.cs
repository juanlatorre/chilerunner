using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiarNivel : MonoBehaviour {

	public static int nivel;

	public Image arica;
	public Image parinacota;

	public Text nombre;
	public Text provincia;
	public Text fundacion;
	public Text superficie;
	public Text poblacion;

	public void Parinacota() {
		arica.GetComponent<Image>().enabled = false;
		parinacota.GetComponent<Image>().enabled = true;
		nombre.text = "Putre";
		provincia.text = "Parinacota";
		fundacion.text = "1580";
		superficie.text = "5.902,5 km";
		poblacion.text = "1.462 Hab.";
		PlayerPrefs.SetInt("Nivel", 0);
	}

	public void Arica() {
		arica.GetComponent<Image>().enabled = true;
		parinacota.GetComponent<Image>().enabled = false;
		nombre.text = "Arica";
		provincia.text = "Arica";
		fundacion.text = "1541";
		superficie.text = "2242.1 km";
		poblacion.text = "210.936 Hab.";
		PlayerPrefs.SetInt("Nivel", 1);
	}

	public void Jugar() {
		SceneManager.LoadScene (3);
	}
}
