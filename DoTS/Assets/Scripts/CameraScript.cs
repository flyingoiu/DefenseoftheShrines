using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	bool cameraLocked = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//this should be a Button, bindable
		if (Input.GetKey ("left shift")) {
						cameraLocked = false;
				} else 
						cameraLocked = true;

		if (cameraLocked == true) {

						
						//if((Math.Abs(target.transform.position - transform.position)))
				
						//

						if (Mathf.Abs (transform.position.x - target.transform.position.x) > .15 || Mathf.Abs (transform.position.y - target.transform.position.y) > .15)
								SmoothPan ();
						else 
								transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10);
				} else
						rigidbody2D.velocity = Vector2.zero;




	}

	void SmoothPan()
	{

		Vector2 smoother = (target.transform.position - rigidbody2D.transform.position)*5;

		rigidbody2D.velocity = smoother;

	}
}
