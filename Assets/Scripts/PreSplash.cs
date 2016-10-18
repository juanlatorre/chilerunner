using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreSplash : MonoBehaviour {

	void Update () {
		if (!Application.isShowingSplashScreen) {
			SceneManager.LoadScene (1);
		}
		PlayerPrefs.SetString ("Skin", "Mapuche");
		PlayerPrefs.SetInt ("Vibration", 1);
	}
}
