using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	Object[] inimigos;
	// Use this for initialization
	void Start () {
		inimigos = Resources.LoadAll("Prefabs/Inimigos/Personagens",typeof(GameObject)) ;
		for(int i = 0 ; i < inimigos.Length;i++){
			if (inimigos[i] != null){
			Instantiate (inimigos[i],gameObject.transform.position, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
