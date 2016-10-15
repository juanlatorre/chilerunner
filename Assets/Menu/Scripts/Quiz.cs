using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class Quiz : MonoBehaviour {

	public float tiempoPorPregunta;
	public Text timeLabel;
	public TextAsset PreguntasXML;
	public Text preguntaLabel;
	public Text opcion1;
	public Text opcion2;
	public Text opcion3;
	public Text opcion4;
	private string preguntaHolder;
	private string respuesta1;
	private string respuesta2;
	private string respuesta3;
	private string respuesta4;
	
	void Awake() {
		if (PreguntasXML != null) {
			XmlTextReader reader = new XmlTextReader(new StringReader(PreguntasXML.text));
			while (reader.Read()) {
				if (reader.Name == "Pregunta") {
					preguntaHolder = reader.GetAttribute("TextoPregunta");
					respuesta1 = reader.GetAttribute("Respuesta1");
					respuesta2 = reader.GetAttribute("Respuesta2");
					respuesta3 = reader.GetAttribute("Respuesta3");
					respuesta4 = reader.GetAttribute("Respuesta4");
                    Debug.Log(reader.Name + " " + reader.GetAttribute("RespuestaCorrecta"));
				}
			}
		}		
	}

	void Start () {
		preguntaLabel.text = preguntaHolder;
		opcion1.text = respuesta1;
		opcion2.text = respuesta2;
		opcion3.text = respuesta3;
		opcion4.text = respuesta4;
		timeLabel.text = "" + ((int)tiempoPorPregunta);
	}
	
	void Update () {
		tiempoPorPregunta -= Time.deltaTime;
		timeLabel.text = "" + ((int)tiempoPorPregunta);
	}
}
