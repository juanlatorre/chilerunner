using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class Player: MonoBehaviour {

	public string state = "Running";
	public AudioSource coin,jumpSound,jumpVoice,parachuteSound,stepSound,chiliSound,deathSound,waterSound,menuSound,okSound;
	public GameObject sparks,chili,step1,step2,step3,step4,step5,step6,step7,step8,step9;
	public Transform respawn;
	public Text coinCounter;
	public Material skin;
	public SunShafts sun;

	private Rigidbody2D rb;
	private GameObject parachute, smoke, skeleton;
	private bool jumping = false;
	private bool parachuteTime = false;
	private bool readyToJump, readyToFly;
	private float maxHeight, speed;
	private int currentStep = 1;
	private bool inTutorial = true;
	private bool locked = true;
	private ParticleSystem waterSparks;
	private Animator anim,parach;

	void Awake(){
		
		GameObject skin = transform.Find("Container/Skeleton/"+PlayerPrefs.GetString ("Skin")).gameObject;
		skin.SetActive(true);
		

	}
	void Start(){
		if (SceneManager.GetActiveScene ().name == "Parinacota") {
			step1.SetActive (true);
			Time.timeScale = 0;
		}
		Color32 col = skin.GetColor("_Color");
		col.a = 255;
		skin.SetColor("_Color",col);
		if (!PlayerPrefs.HasKey ("Coins")) {
			PlayerPrefs.SetInt ("Coins", 0);
		}
		coinCounter.text = PlayerPrefs.GetInt ("Coins").ToString();
		Application.targetFrameRate = 80;
		rb = GetComponent<Rigidbody2D> ();
		waterSparks = transform.Find ("Container/WaterParticles").GetComponent<ParticleSystem> ();
		skeleton = transform.Find("Container/Skeleton").gameObject;
		parachute = transform.Find("Container/Skeleton/Parachute").gameObject;
		smoke = transform.Find("Container/Skeleton/Smoke").gameObject;
		parach = transform.Find("Container/Skeleton/Parachute").GetComponent<Animator>();
		anim = GameObject.FindWithTag("Skeleton").GetComponent<Animator>();
		speed = 28;
		step ();
	}
	void Update(){
		if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0)|| Input.GetKey ("space"))&&inTutorial) {
			okSound.Play ();
			if (currentStep == 1) {
				step1.SetActive (false);
			}
			if (currentStep == 2) {
				step2.SetActive (false);
			}
			if (currentStep == 3) {
				step3.SetActive (false);
				sun.enabled = true;
			}
			if (currentStep == 4) {
				step4.SetActive (false);
			}
			if (currentStep == 5) {
				step5.SetActive (false);
			}
			if (currentStep == 6) {
				step6.SetActive (false);
			}
			if (currentStep == 7) {
				step7.SetActive (false);
			}
			if (currentStep == 8) {
				step8.SetActive (false);
			}
			if (currentStep == 9) {
				step9.SetActive (false);
			}
			Time.timeScale = 1;
			inTutorial = false;
			currentStep++;
			locked = true;
			Invoke ("unlock", 0.2f);
		}
	}
	void FixedUpdate(){
		switch (state)
		{
		case "Running":
			readyToJump = (Input.GetKey ("space") || Input.touchCount > 0) && anim.GetBool ("Grounded") && !jumping && !locked;
			running ();
			break;
		case "Flying":
			readyToFly = (Input.GetKey ("space") || Input.touchCount > 0) && transform.position.y < maxHeight && (transform.eulerAngles.z < 70 || transform.eulerAngles.z > 360 - 90);
			flying ();
			break;
		case "Water":
			swimming ();
			break;
		case "Dying":
			dying ();
			break;
		}
	}
	void step(){
		if (anim.GetBool ("Grounded")) {
			stepSound.Play ();
		}
		if (state == "Water") {
			waterSound.Play ();
		}
		Invoke ("step", 0.25F);
	}
	void unlock(){
		locked = false;
	}
	void gameOver(){
		if (PlayerPrefs.GetInt ("Vibration") == 1) {
			Handheld.Vibrate ();
		}
		endParachute ();
		deathSound.Play ();
		anim.speed = 0;
		state = "Dying";
		rb.gravityScale = 0;
		rb.velocity = new Vector2(0,0);
		//SceneManager.LoadScene (4);
	}
	void dying(){
		Color32 col = skin.GetColor("_Color");
		if (col.a < 10) {
			transform.position = respawn.position;
			startRunning ();
			return;
		}
		col.a -= 8;
		skin.SetColor("_Color",col);
	}
	void stopJumping(){
		jumping = false;
	}
	void startParachute(){
		maxHeight = 75;
		transform.localEulerAngles = new Vector3(0,0,0);
		parachute.SetActive (true);
		parachuteTime = true;
		parach.SetBool ("End", false);
		state = "Flying";
		Invoke ("endParachuteTime", 4F);
	}
	void endParachute(){
		parachute.SetActive (false);
		anim.SetBool ("Flying", false);
		CancelInvoke("endParachuteTime");
	}
	void endParachuteTime(){
		parachuteTime = false;
		parach.SetBool ("End", true);
	}
	void endChili(){
		speed = 28;
		//smoke.SetActive (false);
		anim.SetBool("Chili",false);
		smoke.GetComponent<ParticleSystem> ().loop = false;
	}
	void startRunning(){
		skeleton.transform.position = transform.Find("Container").gameObject.transform.position;
		anim.speed = 1;
		Color32 col = skin.GetColor("_Color");
		col.a = 255;
		skin.SetColor("_Color",col);
		state = "Running";
		rb.gravityScale = 23;
		waterSparks.Stop ();
	}
	void jump(){
		jumping = true;
		Invoke ("stopJumping", 0.27F);
		jumpSound.pitch = Random.Range(0.96f,1.2f);
		jumpVoice.Play ();
		jumpSound.Play ();
	}
	void running(){
		
		RaycastHit2D[] hits = new RaycastHit2D[2];

		if (jumping) {
			rb.velocity = new Vector2 (rb.velocity.x, 34);
		}
		rb.velocity = new Vector2 (speed, rb.velocity.y);




		int h = Physics2D.RaycastNonAlloc(transform.position, -Vector2.up, hits);

		if (readyToJump) {
			jump ();
		}
		if (h > 1) {
			int index = -1;
			if (hits [1].transform.gameObject.tag == "Ground" && transform.position.y - hits [1].point.y < 2) {
				anim.SetBool ("Grounded", true);
			} else {
				anim.SetBool ("Grounded", false);
			}
			for (int i = 0; i < hits.Length; i++) {
				if (hits [i].transform.gameObject.tag == "Ground") {
					index = i;
				}
			}
			if (index != -1) {
				if (transform.position.y - hits [index].point.y < 20) {
					float angle = -Mathf.Atan2 (hits [index].normal.x, hits [index].normal.y) * Mathf.Rad2Deg; //get angle
					transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0.0F, 0.0F, angle), 0.3F); 
				}
			}
			else {
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0.0F, 0.0F, 0.0F), 0.1F); 

			}
		} 
	}
	void flying(){
		Debug.Log (transform.eulerAngles.z);
		rb.gravityScale = 0;
		rb.velocity = transform.right * 60;
		anim.SetBool ("Flying", true);
		if (!parachuteTime) {
			maxHeight -= Time.deltaTime * 10;
		}
		if (readyToFly) {
			transform.Rotate (Vector3.forward * Time.deltaTime * 50, Space.Self);
		}else {
			if (transform.eulerAngles.z > 360-70 || transform.eulerAngles.z < 90) {
				transform.Rotate (-Vector3.forward * Time.deltaTime * 50, Space.Self);
			}
		}
	}
	void swimming(){
		Debug.Log (skeleton.transform.position.y);
		rb.velocity = new Vector2 (speed, rb.velocity.y);
		skeleton.transform.position = new Vector3 (skeleton.transform.position.x, skeleton.transform.position.y - 2*Time.deltaTime,skeleton.transform.position.z);
		if (Input.touchCount > 0 && skeleton.transform.position.y < -22.83F) {
			if (Input.GetKeyDown ("space") || Input.GetTouch (0).phase == TouchPhase.Began) {
				skeleton.transform.position = new Vector3 (skeleton.transform.position.x, skeleton.transform.position.y + 15*Time.deltaTime,skeleton.transform.position.z);
			}
		}
		if (Input.GetKeyDown ("space") && skeleton.transform.position.y < -22.9F) {
			skeleton.transform.position = new Vector3 (skeleton.transform.position.x, skeleton.transform.position.y + 15*Time.deltaTime,skeleton.transform.position.z);
		}
		if (skeleton.transform.position.y < -26.83F) {
			gameOver ();
		}

	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Parachute") {
			rb.AddForce (new Vector2 (0, 1000));
			parachuteSound.Play ();
			Destroy (coll.gameObject);
			Invoke ("startParachute", 0.3f);
		}
		if (coll.gameObject.tag == "Ground" && state == "Flying") {
			endParachute ();
			startRunning ();
		}
		if (coll.gameObject.tag == "Ground" && state == "Water") {
			startRunning ();
		}
		if (coll.gameObject.tag == "Death") {
			gameOver ();
		}
		if (coll.gameObject.tag == "Water") {
			state = "Water";
			anim.SetBool ("Grounded", true);
			waterSparks.Play ();
		}
	}
	void OnTriggerEnter2D (Collider2D coll) {

		if (coll.gameObject.tag == "Coin") {
			Instantiate(sparks, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
			Destroy(coll.gameObject);
			coin.pitch = 1.46f;
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 10);
			PlayerPrefs.SetInt (coll.gameObject.GetInstanceID().ToString(), 0);
			coinCounter.text = PlayerPrefs.GetInt ("Coins").ToString();
			coin.Play ();
		}
		if (coll.gameObject.tag == "Ficha") {
			Instantiate(sparks, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
			Destroy(coll.gameObject);
			coin.pitch = 1.2f;
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1);
			coinCounter.text = PlayerPrefs.GetInt ("Coins").ToString();
			coin.Play ();
		}
		if (coll.gameObject.tag == "Chili") {
			Instantiate(chili, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
			Destroy(coll.gameObject);
			chiliSound.Play ();
			speed = 55;
			smoke.GetComponent<ParticleSystem> ().loop = true;
			smoke.GetComponent<ParticleSystem> ().Play ();
			smoke.SetActive (true);
			anim.SetBool("Chili",true);
			Invoke ("endChili", 3f);
		}
		if (coll.gameObject.name == "s2") {
			step2.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s3") {
			sun.enabled = false;
			step3.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s4") {
			step4.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s5") {
			step5.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s6") {
			step6.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s7") {
			step7.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s8") {
			step8.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.gameObject.name == "s9") {
			step9.SetActive (true);
			inTutorial = true;
			Time.timeScale = 0;
			menuSound.Play ();
			Destroy (coll.gameObject);
		}
	}
}
