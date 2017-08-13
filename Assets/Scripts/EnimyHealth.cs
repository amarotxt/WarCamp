using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyHealth : MonoBehaviour {
	public float enimyHealth = 1;

	void Update () {
		if (enimyHealth < 0) {
			Destroy (gameObject);
		}
	}

}
