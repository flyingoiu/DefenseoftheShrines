using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = .5f;
	bool facingUp = true;

	Animator anim;

	//this might come in handy for 4-direction rotation, but we may just skip to 360 degree orientation
	//enum orientation {UP, DOWN, LEFT, RIGHT};

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		anim.SetFloat ("hSpeed", Mathf.Abs (moveHorizontal));
		anim.SetFloat ("vSpeed", Mathf.Abs (moveVertical));

		rigidbody2D.velocity = new Vector2 (moveHorizontal * maxSpeed,moveVertical * maxSpeed);

		if (moveVertical > 0 && !facingUp)
						Flip ();
				else if (moveVertical < 0 && facingUp)
						Flip ();

	
	}

	void Update()
	{
		//key stuff.  don't use getKeydown.  Go to input manager, make a button
		//if()

		//nice way to do forces for knockbacks, nb
		//rigidbody2D.AddForce(new Vector2(x,y));

	}

	void Flip()
	{
		facingUp = !facingUp;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;


	}

	//We will need to adapt flip into rotation when we do mouse controls
	/*
	void Rotate()
	{
		//
		//
		//


	}
*/
}
