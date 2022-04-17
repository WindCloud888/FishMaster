using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_Move : MonoBehaviour {
	public float speed = 1f;
	public Vector3 dir = Vector3.right;   //.right是x轴的正方向

	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir * speed * Time.deltaTime);

	}
}
