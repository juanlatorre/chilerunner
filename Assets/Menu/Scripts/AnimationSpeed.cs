using UnityEngine;
using System.Collections;

public class AnimationSpeed : MonoBehaviour {

	public Animator animator;
	public float velocidadAnimacion;	
	public void Start() {
		animator.speed = velocidadAnimacion;
	}
}
