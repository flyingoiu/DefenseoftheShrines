using UnityEngine;
using System.Collections;

public class Amulet : MonoBehaviour {

	// Use this for initialization
	void Start () {

		rigidbody2D.AddForce (new Vector2(-100f,-100f));

	
	}
	
	// Update is called once per frame
	void Update () {


		rigidbody2D.AddTorque (Mathf.PI * 2);
	
	}
}
