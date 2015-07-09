using UnityEngine;
using System.Collections;

public class Amulet : MonoBehaviour {

    public GameObject target;

    [SerializeField]
    private float startingSpin = Mathf.PI * 2 * 100;
    private float spinAcceleration = 1.4f;
    private float velocity = 1.3f;
    private float acceleration = .07f;
    private float waitToHome = .5f;
    private Vector2 initialForce = new Vector2(-50f, -30f);
     //private float acceleration = 1f;


	// Use this for initialization
	void Start () {


        target = GameObject.FindGameObjectWithTag("Player");
		GetComponent<Rigidbody2D>().AddRelativeForce (initialForce);
        GetComponent<Rigidbody2D>().AddTorque(startingSpin);

        StartCoroutine(delayLaunch(waitToHome));

	
	}

    IEnumerator delayLaunch(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(homing());
    }

	// Update is called once per frame
	void Update () {


		

        //GetComponent<Rigidbody2D>().AddForce(new Vector2(-100f, -100f));

        //Vector2 direction = target.transform.position - transform.position;
        //GetComponent<Rigidbody2D>().AddForce(direction.normalized * 1f, ForceMode2D.Force);


	
	}

    IEnumerator homing()
    {
        while(true)
        { 
        Vector3 direction = (target.transform.position - transform.position).normalized;

        velocity += acceleration;

        GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * (velocity) * Time.fixedDeltaTime);
        yield return null;
        }
    }


    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().AddTorque(spinAcceleration);



    }

}
