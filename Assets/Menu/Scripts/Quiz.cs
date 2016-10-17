using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

	// Time Handler
	public float tiempoPorPregunta;
	public Text timeLabel;

	// Audio
	public AudioClip correctSound;
	public AudioClip incorrectSound;
	private AudioSource source;

	// Penalización
	public GameObject plus15;
	public GameObject minus15;
	public GameObject parentTime;

	// Puntaje	
	private float puntaje = 0;
	private int badCount = 0;
	public GameObject cuentaPuntaje;
	public Text puntajeObtenido;
	public Text totalGanado;
	public float multiplicadorFloat;
	private float totalFloat;
	private int monedas;

	// Siguiente Preguntas
	private int numEtapa = 0;

	// Preguntas
	public GameObject[] arrayPreguntas;

	void Awake() {
		source = GetComponent<AudioSource>();
	}

	void Start () {
		ShuffleArray(arrayPreguntas);
		arrayPreguntas[numEtapa].SetActive(true);
		// Time Handler
		timeLabel.text = "" + ((int)tiempoPorPregunta);	
	}
	
	void Update () {

		// Time Handler
		tiempoPorPregunta -= Time.deltaTime;
		timeLabel.text = "" + ((int)tiempoPorPregunta);
		if (tiempoPorPregunta == 0) {
			Debug.Log("Se acabó el tiempo!");
			StartCoroutine(RecuentoPuntaje());
		}
	}

	public static void ShuffleArray<T>(T[] arr) {
		for (int i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range(0, i);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}

	public void calcularPuntaje() {
		switch (badCount) {
			case 3:
				puntaje += 0;
				break;
			case 2:
				puntaje += 1;
				break;
			case 1:
				puntaje += 3;
				break;
			case 0:
				puntaje += 5;
				break;
			default:
				puntaje += 0;
				break;
        }
		badCount = 0;
	}

	public void siguientePregunta() {
		if (numEtapa < (arrayPreguntas.Length-1)) {
			numEtapa++;
			arrayPreguntas[numEtapa - 1].SetActive(false); //Desactivo la pregunta anterior
			arrayPreguntas[numEtapa].SetActive(true); //Activo la pregunta actual
		} else {
			StartCoroutine(RecuentoPuntaje());
		}	
	}

	IEnumerator RecuentoPuntaje() {
		arrayPreguntas[numEtapa].SetActive(false);
		cuentaPuntaje.SetActive(true);
		totalFloat = puntaje*multiplicadorFloat;
		monedas += ((int)totalFloat);
		PlayerPrefs.SetInt("Monedas", PlayerPrefs.GetInt("Monedas")+monedas);
		puntajeObtenido.GetComponent<Text>().enabled = true;
		for (int i = 0; i <= puntaje; i++) {
			puntajeObtenido.text = "" + i;
			yield return new WaitForSeconds(0.01f);
		}
		totalGanado.GetComponent<Text>().enabled = true;
		for (float k = 0; k <= totalFloat; k++) {
			totalGanado.text = "" + k;
			yield return new WaitForSeconds(0.01f);
		}
		Debug.Log("Se acabó el Array");
	}
	
	public void Correcto(Button btnCorrect) {
		calcularPuntaje();
		btnCorrect.interactable = false;
		tiempoPorPregunta = tiempoPorPregunta + 15;
		GameObject go = Instantiate(plus15, new Vector3 (0,0,0), Quaternion.identity) as GameObject;
		go.transform.SetParent(parentTime.transform, false);
		ColorBlock colorBlock = btnCorrect.GetComponent<Button>().colors;
		colorBlock.disabledColor = new Color(142/255f, 189/255f, 119/255f, 1.0f);
		btnCorrect.GetComponent<Button>().colors = colorBlock;
		source.PlayOneShot(correctSound,1);
		siguientePregunta();
	}

	public void Incorrecto(Button btnWrong) {
		badCount = badCount + 1;
		btnWrong.interactable = false;
		tiempoPorPregunta = tiempoPorPregunta - 15;
		GameObject go = Instantiate(minus15, new Vector3 (0,0,0), Quaternion.identity) as GameObject;
		go.transform.SetParent(parentTime.transform, false);
		ColorBlock colorBlock = btnWrong.GetComponent<Button>().colors;
		colorBlock.disabledColor = new Color(228/255f, 144/255f, 157/255f, 1.0f);
		btnWrong.GetComponent<Button>().colors = colorBlock;
		source.PlayOneShot(incorrectSound,1);
	}
}
