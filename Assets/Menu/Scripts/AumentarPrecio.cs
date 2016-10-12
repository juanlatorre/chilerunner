using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AumentarPrecio : MonoBehaviour {

	public Text item;
	public float precioItem;
	public float subePorCompra;
	public Button botonDeCompra;
	public bool puedeComprar;
	private int getMonedas;

	public void Update () {
		getMonedas = Wallet.monedas;
		item = gameObject.GetComponent<Text>();
		item.text = "$" + precioItem;

		if (precioItem > getMonedas) {
			botonDeCompra.GetComponent<Button>().interactable = false;
		} else {
			botonDeCompra.GetComponent<Button>().interactable = true;
		}
	}
	
	public void onClick() {
		float precioNuevo = precioItem*subePorCompra;
		precioItem = ((int)precioNuevo);
	}
}
