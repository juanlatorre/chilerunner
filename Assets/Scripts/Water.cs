using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	float offset = 0;
	public Material rend;
	void Update() {
		offset -= Time.deltaTime * 20;
		rend.SetTextureOffset("_MainTex",new Vector2(offset, 0));
	}
}