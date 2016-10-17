using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CambiarPersonaje : MonoBehaviour {

	public static string skin;
	public Image selector;

	public GameObject panelPersonajes;
	public GameObject panelMenu;

	// Sprites
	public Sprite[] charaSprites;

	// Personajes
	public Image prat;
	public Image huaso;
	public Image machi;
	public Image lonco;
	public Image trauco;
	public Image carabinero;
	public Image bachelet;
	public Image german;
	public Image farkas;

	public void Prat() {
		prat.GetComponent<Image>().enabled = true;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[0];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Prat");

	}

	public void Huaso() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = true;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[1];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Huaso");
	}

	public void Machi() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = true;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[2];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Machi");
	}

	public void Lonco() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = true;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[3];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Lonco");
	}

	public void Trauco() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = true;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[4];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Trauco");
	}

	public void Carabinero() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = true;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[5];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Carabinero");
	}

	public void Bachelet() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = true;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[6];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Bachelet");
	}

	public void German() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = true;
		farkas.GetComponent<Image>().enabled = false;
		selector.sprite = charaSprites[7];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "German");
	}

	public void Farkas() {
		prat.GetComponent<Image>().enabled = false;
		huaso.GetComponent<Image>().enabled = false;
		machi.GetComponent<Image>().enabled = false;
		lonco.GetComponent<Image>().enabled = false;
		trauco.GetComponent<Image>().enabled = false;
		carabinero.GetComponent<Image>().enabled = false;
		bachelet.GetComponent<Image>().enabled = false;
		german.GetComponent<Image>().enabled = false;
		farkas.GetComponent<Image>().enabled = true;
		selector.sprite = charaSprites[8];
		panelPersonajes.SetActive(false);
		panelMenu.SetActive(true);
		PlayerPrefs.SetString("Skin", "Farkas");
	}
}
