using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = 1;
	public float focusreduction = 0.5f;
	bool facingUp = true;
	bool moving = false;
	bool focus = false;

	Animator anim;

	//this might come in handy for 4-direction rotation, but we may just skip to 360 degree orientation
	//enum orientation {UP, DOWN, LEFT, RIGHT};

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		if (Input.GetKey ("left shift"))
						focus = true;
				else
						focus = false;



		//print (focus);

		float focusmultiplier = (focus)?(focusreduction) : (1.0f);

		//all orthogonal movementspeed calculations should go here.  may want to consolidate into a single speed stat and then copy to both
		float horizontalspeed = moveHorizontal * maxSpeed * focusmultiplier;
		float verticalspeed   = moveVertical   * maxSpeed * focusmultiplier;



		if (horizontalspeed != 0 || verticalspeed != 0) {
			moving = true;
			anim.SetBool ("moving", moving);		

		} else {
			moving = false;
			anim.SetBool ("moving", moving);	
		}

		//print (moving);

		//to keep diagonal movement same speed as orthogonal
		if(moveHorizontal!=0 && moveVertical !=0)
		{
			horizontalspeed = horizontalspeed/Mathf.Sqrt(2);
			verticalspeed = verticalspeed/Mathf.Sqrt(2);	
		}

		print (horizontalspeed + ", " + verticalspeed);
		rigidbody2D.velocity = new Vector2 (horizontalspeed, verticalspeed);

		if (moveVertical > 0 && !facingUp && !focus)
						Flip ();
				else if (moveVertical < 0 && facingUp & !focus)
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
