using UnityEngine;
using System.Collections;

public class TowerControllerScript : MonoBehaviour {

	public bool shooting = false;
	Collider2D[] Towerrangecollider;
	float range = 2;
	Animator anim;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

	
	
	}
	
	// Update is called once per frame
	void Update () {


		Vector2 pos = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
		
		
		
		
		//theres a layermask parameter you can use to only check objects on a specific layer (e.g. enemy team layer)
		//may need to make this more efficient later

		Towerrangecollider = Physics2D.OverlapCircleAll (pos,range);


		//this conditional is janky in two ways.
		//first, it starts from one so that the tower does not collide with itself
		//second, it just checks if it's colliding with ANYTHING, so it will eventually need to filter by layer (for enemy units only)
		if (Towerrangecollider.Length > 1) {
			shooting = true;
			anim.SetBool ("shooting",true);		
		} else {
			shooting = false;
			anim.SetBool ("shooting",false);
				}
		
		}

	//this will be complex logic regarding which target to shoot at based on aggro
	void targettinglogic()
	{

	}


}
